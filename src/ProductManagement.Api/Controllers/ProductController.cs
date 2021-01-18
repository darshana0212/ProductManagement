using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data;
using ProductManagement.Service;

namespace ProductManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductCommandService _productCommandService;
        private readonly IProductQueryService _productQueryService;

        public ProductController(IProductCommandService productCommandService, IProductQueryService productQueryService)
        {
            _productCommandService = productCommandService;
            _productQueryService = productQueryService;
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById([FromRoute] int id)
        {
           return Ok(_productQueryService.GetProduct(id));            
        }

        [HttpGet()]
        public IActionResult GetProducts()
        {
            return Ok(_productQueryService.GetProducts());
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
           return Ok(_productCommandService.SaveProduct(product));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (product.Id != id)
            {
                return BadRequest("Product Id is invalid");
            }

            _productCommandService.UpdateProduct(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            _productCommandService.DeleteProduct(id);
            return Ok();
        }
    }
}
