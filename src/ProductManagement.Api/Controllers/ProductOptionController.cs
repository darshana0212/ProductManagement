using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data;
using ProductManagement.Service;

namespace ProductManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductOptionController : ControllerBase
    {
        private readonly IProductCommandService _productCommandService;
        private readonly IProductQueryService _productQueryService;

        public ProductOptionController(IProductCommandService productCommandService, IProductQueryService productQueryService)
        {
            _productCommandService = productCommandService;
            _productQueryService = productQueryService;
        }

        [HttpPost]
        public IActionResult AddProductOption([FromBody] ProductOption productOption)
        {
            return Ok(_productCommandService.SaveProductOption(productOption));
        }
    }
}
