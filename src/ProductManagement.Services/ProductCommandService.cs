using ProductManagement.Data;
using System;

namespace ProductManagement.Service
{
    public class ProductCommandService : IProductCommandService
    {
        public Product GetProduct()
        {
            return new Product("code1", 10,"code2");
        }
    }
}
