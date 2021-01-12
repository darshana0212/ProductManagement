using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data;
using ProductManagement.Service;

namespace ProductManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public Product GetData()
        {
            var productCommandService = new ProductCommandService();
            return productCommandService.GetProduct();
        }
    }
}
