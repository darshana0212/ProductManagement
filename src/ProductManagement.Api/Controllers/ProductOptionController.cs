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

        [HttpGet]
        public IActionResult GetProductOptionById([FromQuery] int productId)
        {
            return Ok(_productQueryService.GetProductOptionsByProductId(productId));
        }

        [HttpPut("{optionId}")]
        public IActionResult UpdateProductOption([FromRoute] int optionId, [FromBody] ProductOption productOption)
        {
            if (productOption.Id != optionId)
            {
                return BadRequest("ProductOption Id is invalid");
            }

            _productCommandService.UpdateProductOption(productOption);
            return Ok();
        }

        [HttpDelete("{optionId}")]
        public IActionResult DeleteProductOption([FromRoute] int optionId)
        {
            _productCommandService.DeleteProductOption(optionId);
            return Ok();
        }

        [HttpDelete()]
        public IActionResult DeleteProductOptionsByProductId([FromQuery] int productId)
        {
            _productCommandService.DeleteProductOptionsByProductId(productId);
            return Ok();
        }
    }
}
