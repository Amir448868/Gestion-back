using Carniceria.Entities;
using Carniceria.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carniceria.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    

    public class ProductController:ControllerBase
    {
        private readonly ProductServices _productServices;

        public ProductController(ProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productServices.GetProducts());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(_productServices.GetProduct(id));
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            return Ok(_productServices.CreateProduct(product));
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            return Ok(_productServices.UpdateProduct(id, product));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productServices.DeleteProduct(id);
            return Ok();
        }

    }
}
