using ProductManagement.Data;
using ProductManagement.Data.Repository;

namespace ProductManagement.Service
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly IProductRepository _productRepository;
        public ProductQueryService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

    }
}
