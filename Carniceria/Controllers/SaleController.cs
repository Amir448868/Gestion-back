using Carniceria.Data.Models.Dto;
using Carniceria.Entities;
using Carniceria.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carniceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SaleController:ControllerBase
    {
        private readonly SaleServices _saleServices;

        public SaleController(SaleServices saleServices)
        {
            _saleServices = saleServices;
        }

        [HttpGet]
        public IActionResult GetSales()
        {
            return Ok(_saleServices.GetSales());
        }

        [HttpGet]
        [Route("by-date/{date}")]
        public IActionResult GetSaleByDate(string date)
        {
            return Ok(_saleServices.GetSaleByDate(date));
        }

        [HttpGet]
        [Route("by-product/{idproduct}")]
        public IActionResult GetSaleByProduct(int idproduct)
        {
            return Ok(_saleServices.GetSaleByProduct(idproduct));
        }

        [HttpGet]
        [Route("by-month/{month}")]
        public IActionResult GetSaleByMonth(string month)
        {
            return Ok(_saleServices.GetSaleByMonth(month));
        }



        [HttpPost]
        public IActionResult CreateSale([FromBody] List<SaleForCreation> sale)
        {
            if (sale == null || sale.Count == 0)
            {
                return BadRequest("Invalid data received");
            }

            // Puedes añadir más validaciones si es necesario
            return Ok(_saleServices.CreateSales(sale));
        }
    }
}
