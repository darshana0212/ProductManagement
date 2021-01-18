using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                return _productRepository.AddProduct(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding Product");
                throw;
            }
        }

        public int SaveProductOption(ProductOption productOption)
        {
            try
            {
                return _productRepository.AddProductOption(productOption);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding Product Option");
                throw;
            }
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

        public void UpdateProductOption(ProductOption productOption)
        {
            try
            {
                ProductOption option = _productRepository.GetProductOptionById(productOption.Id);

                option.Code = productOption.Code;
                option.Description = productOption.Description;
                
                _productRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating Product Option");
                throw;
            }
        }

        public void DeleteProductOption(int optionId)
        {
            try
            {
                ProductOption existingProductOption = _productRepository.GetProductOptionById(optionId);

                if (existingProductOption == null)
                {
                    throw new Exception($"ProductOption with Id {optionId} not found");
                }

                _productRepository.DeleteProductOption(existingProductOption);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting Product Option");
                throw;
            }
        }

        public void DeleteProductOptionsByProductId(int productId)
        {
            try
            {
                List<ProductOption> productOptions = _productRepository.GetProductOptionsByProductId(productId);

                if (!productOptions.Any())
                {
                    throw new Exception($"No ProductOptions found for Product Id {productId}");
                }

                _productRepository.DeleteProductOptions(productOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting Product Options");
                throw;
            }
        }
    }
}
