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
        public IActionResult GetData([FromRoute] int id)
        {
           return Ok(_productQueryService.GetProduct(id));            
        }


        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
           return Ok(_productCommandService.SaveProduct(product));
        }
    }
}
