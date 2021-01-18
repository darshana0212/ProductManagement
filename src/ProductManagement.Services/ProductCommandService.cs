using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using ProductManagement.Data;
using ProductManagement.Data.Repository;

namespace ProductManagement.Service
{
    public class ProductCommandService : IProductCommandService
    {
        private readonly ILogger<ProductCommandService> _logger;
        private readonly IProductRepository _productRepository;
        public ProductCommandService(IProductRepository productRepository, ILogger<ProductCommandService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }
        public int SaveProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public int SaveProductOption(ProductOption productOption)
        {
            return _productRepository.AddProductOption(productOption);
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                Product existingProduct = _productRepository.GetProduct(product.Id);

                if (existingProduct == null)
                {
                    throw new Exception($"Product with Id {product.Id} not found");
                }

                existingProduct.Price = product.Price;
                existingProduct.Code = product.Code;
                existingProduct.Description = product.Description;

                _productRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating Product");
                throw;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                Product existingProduct = _productRepository.GetProduct(id);

                if (existingProduct == null)
                {
                    throw new Exception($"Product with Id {id} not found");
                }

                _productRepository.Delete(existingProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting Product");
                throw;
            }
        }
    }
}
