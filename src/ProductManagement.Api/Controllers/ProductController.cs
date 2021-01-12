using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
