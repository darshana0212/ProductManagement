using ProductManagement.Data;

namespace ProductManagement.Service
{
    public class ProductCommandService : IProductCommandService
    {
        public Product GetProduct() => new Product("code1", 10, "code2");
    }
}
