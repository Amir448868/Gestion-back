using Carniceria.Data;
using Carniceria.Data.Models.Dto;
using Carniceria.Entities;

namespace Carniceria.Services
{
    public class SaleServices
    {
        private readonly CarniceriaContext _context;

        public SaleServices(CarniceriaContext context)
        {
            _context = context;
        }

        public List<SaleForview> GetSales()
        {
            return _context.Sales.ToList();
        }

        public List<SaleForView> GetSaleByDate(string date)
        {
            DateTime saleDate;
            if (DateTime.TryParse(date, out saleDate))
            {


                string formattedDate = saleDate.ToString("yyyy-MM-dd");

                // Obtén las ventas junto con la información del producto en una sola consulta
                var sales = _context.Sales
                    .Where(x => x.date == formattedDate)
                    .Select(x => new
                    {
                        Sale = x,
                        Product = _context.Products.FirstOrDefault(p => p.id == x.idProduct)
                    })
                    .ToList();

                var salesForView = new List<SaleForView>();
                foreach (var item in sales)
                {
                    if (item.Product != null) // Verificar que el producto exista
                    {
                        var saleForView = new SaleForView
                        {
                            id = item.Sale.id,
                            productName = item.Product.name,
                            total = (int)item.Sale.total,
                            amount = (int)item.Sale.amount,
                            price = (int)item.Product.price,
                            dateForView = item.Sale.date
                        };
                        salesForView.Add(saleForView);
                    }
                }

                return salesForView;
            }

            // Si el formato de la fecha no es válido, devolver null
            return null;
        }

        public List<SaleForView> GetSaleByMonth(string month)
        {
            DateTime saleMonth;
            if (DateTime.TryParse(month, out saleMonth))
            {
                string formattedMonth = saleMonth.ToString("yyyy-MM");

                var sales = _context.Sales
                    .Where(x => x.date.Contains(formattedMonth))
                    .GroupBy(x => x.idProduct)
                    .Select(g => new
                    {
                        idProduct = g.Key,
                        Total = g.Sum(s => (double)s.total),
                        Amount = g.Sum(s => (double)s.amount),
                    })
                    .ToList();

                var salesForView = new List<SaleForView>();
                foreach (var item in sales)
                {
                    var product = _context.Products.FirstOrDefault(p => p.id == item.idProduct);
                    if (product != null)
                    {
                        var saleForView = new SaleForView
                        {
                            id = item.idProduct,
                            productName = product.name,
                            total = (int)item.Total,
                            amount = (int)item.Amount,
                            price = (int)product.price,
                        };
                        salesForView.Add(saleForView);
                    }
                }

                return salesForView;
            }

            return null;
        }
        public SaleForView GetSaleByProduct(int idProduct)
        {
            var sales = _context.Sales
                .Where(x => x.idProduct == idProduct)
                .GroupBy(x => x.idProduct)
                .Select(x => new
                {
                    Total = x.Sum(p => (double)p.total),  // Mantén la precisión con decimal
                    Amount = x.Sum(p => (double)p.amount)
                })
                .FirstOrDefault();  // Obtén el primer resultado o null si no hay ventas

            if (sales == null)
            {
                return new SaleForView
                {
                    id = 0,
                    productName = "",
                    total = 0,
                    amount = 0,
                    price = 0
                };
            }

            var product = _context.Products
                .FirstOrDefault(p => p.id == idProduct);

            if (product == null)
            {
                return new SaleForView
                {
                    id = 0,
                    productName = "",
                    total = 0,
                    amount = 0,
                    price = 0
                };
            }

            var saleForView = new SaleForView
            {
                id = product.id,
                productName = product.name,
                total = (int)sales.Total,  // Convierte a int si es necesario
                amount = (int)sales.Amount,
                price = (int)product.price
            };

            return saleForView;
        }

        public List<SaleForview> CreateSales(List<SaleForCreation> sales)
        {
            var newSales = new List<SaleForview>();

            foreach (var sale in sales)
            {
                try
                {
                    var product = _context.Products.FirstOrDefault(x => x.id == sale.idProduct);
                    if (product == null)
                    {
                        throw new ArgumentException($"El producto con ID {sale.idProduct} no fue encontrado.");
                    }

                    var newSale = new SaleForview
                    {
                        idProduct = sale.idProduct,
                        total = sale.amount * product.price,
                        date = DateTime.Now.ToString("yyyy-MM-dd"),
                        amount = sale.amount
                    };

                    _context.Sales.Add(newSale);
                    newSales.Add(newSale);
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it accordingly
                    throw new InvalidOperationException("Error al procesar la venta.", ex);
                }
            }

            _context.SaveChanges();
            return newSales;
        }


        public SaleForview UpdateSale(string date, SaleForview sale)
        {
            var existingSale = _context.Sales.FirstOrDefault(x => x.date == date);
            if (existingSale != null)
            {
                existingSale.idProduct = sale.idProduct;
                existingSale.total = sale.total;
                existingSale.date = sale.date;
                _context.Sales.Update(existingSale);
                _context.SaveChanges();
            }
            return existingSale;
        }
    }
}
