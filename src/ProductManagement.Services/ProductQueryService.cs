using Microsoft.Extensions.Logging;
using ProductManagement.Data;
using ProductManagement.Data.Repository;
using System;
using System.Collections.Generic;

namespace ProductManagement.Service
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductQueryService> _logger;

        public ProductQueryService(IProductRepository productRepository, ILogger<ProductQueryService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public Product GetProduct(int id)
        {
            try
            {
                return _productRepository.GetProduct(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving Product By Id - {id}");
                throw;
            }
        }

        public List<ProductOption> GetProductOptionsByProductId(int productId)
        {
            try
            {
                return _productRepository.GetProductOptionsByProductId(productId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving Product Options By Product Id - {productId}");
                throw;
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
                return _productRepository.GetAllProducts();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving Products");
                throw;
            }        
        }
    }
}
