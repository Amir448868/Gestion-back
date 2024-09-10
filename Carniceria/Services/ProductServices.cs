using Carniceria.Data;
using Carniceria.Entities;

namespace Carniceria.Services
{
    public class ProductServices
    {
        private readonly CarniceriaContext _context;

        public ProductServices(CarniceriaContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {

            var products = _context.Products.Where(x => x.isDeleted == true).ToList();
            return products;

        }

        public Product GetProduct(int id)
        {
            return _context.Products.FirstOrDefault(x => x.id == id);
        }

        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product UpdateProduct(int id, Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(x => x.id == id);
            if (existingProduct != null)
            {
                existingProduct.name = product.name;
                existingProduct.price = product.price;
                _context.Products.Update(existingProduct);
                _context.SaveChanges();
            }
            return existingProduct;
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.id == id);
            if (product != null)
            {
                product.isDeleted = true;
                _context.Products.Update(product);
            }
        }
    }
}
