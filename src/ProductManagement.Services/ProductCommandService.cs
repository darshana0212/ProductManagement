using System;
using System.Collections.Generic;
using System.Text;
using ProductManagement.Data;
using ProductManagement.Data.Repository;

namespace ProductManagement.Service
{
    public class ProductCommandService : IProductCommandService
    {
        private readonly IProductRepository _productRepository;
        public ProductCommandService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public int SaveProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public int SaveProductOption(ProductOption productOption)
        {
            return _productRepository.AddProductOption(productOption);
        }

    }
}
