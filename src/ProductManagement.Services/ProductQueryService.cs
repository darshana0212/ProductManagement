using ProductManagement.Data;

namespace ProductManagement.Service
{
    public class ProductQueryService : IProductQueryService
    {
        public Product GetProduct() => new Product("code1", 10, "code2");
    }
}
