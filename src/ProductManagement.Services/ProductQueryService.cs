using ProductManagement.Data;
using ProductManagement.Data.Repository;
using System.Collections.Generic;

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

        public List<Product> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}
