using Microsoft.Extensions.Logging;
using Moq;
using ProductManagement.Data;
using ProductManagement.Data.Repository;
using ProductManagement.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProductManagement.Api.Tests.Service
{
    public class ProductCommandServiceTests
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<ILogger<ProductCommandService>> _logger;

        public ProductCommandServiceTests()
        {
            _productRepository = new Mock<IProductRepository>();
            _logger = new Mock<ILogger<ProductCommandService>>();
        }

        [Fact]
        public void SaveProduct_PositiveScenario()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Code = "Code",
                Description = "Description",
                Price = 10
            };

            _productRepository.Setup(x => x.AddProduct(product)).Returns(product.Id);
            var productCommandService = new ProductCommandService(_productRepository.Object, _logger.Object);

            // Act
            int productId = productCommandService.SaveProduct(product);

            // Assert
            _productRepository.Verify(x => x.AddProduct(product), Times.Once);
            Assert.Equal(productId, product.Id);
        }

        [Fact]
        public void SaveProduct_ThrowsException()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Code = "Code",
                Description = "Description",
                Price = 10
            };

            _productRepository.Setup(x => x.AddProduct(product)).Throws(new Exception("An error occurred while adding new Product"));
            var productCommandService = new ProductCommandService(_productRepository.Object, _logger.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => productCommandService.SaveProduct(product));
        }

        [Fact]
        public void SaveProductOption_PositiveScenario()
        {
            // Arrange
            var productOption = new ProductOption
            {
                Id = 1,
                Code = "PO1",
                Description = "Description",
                ProductId = 1
            };

            _productRepository.Setup(x => x.AddProductOption(productOption)).Returns(productOption.Id);
            var productCommandService = new ProductCommandService(_productRepository.Object, _logger.Object);

            // Act
            int productOptionId = productCommandService.SaveProductOption(productOption);

            // Assert
            _productRepository.Verify(x => x.AddProductOption(productOption), Times.Once);
            Assert.Equal(productOptionId, productOption.Id);
        }

        [Fact]
        public void SaveProductOption_ThrowsException()
        {
            // Arrange
            var productOption = new ProductOption
            {
                Id = 1,
                Code = "PO1",
                Description = "Description",
                ProductId = 1
            };

            _productRepository.Setup(x => x.AddProductOption(productOption)).Throws(new Exception("An error occurred while adding new Product Option"));
            var productCommandService = new ProductCommandService(_productRepository.Object, _logger.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => productCommandService.SaveProductOption(productOption));
        }

        [Fact]
        public void UpdateProduct_PositiveScenario()
        {
            // Arrange
            var existingProduct = new Product
            {
                Id = 1,
                Code = "PO",
                Description = "Old Product",
                Price = 9
            };

            var updatedProduct = new Product
            {
                Id = 1,
                Code = "PO1",
                Description = "New Description",
                Price = 10
            };

            _productRepository.Setup(x => x.GetProduct(updatedProduct.Id)).Returns(existingProduct);
            var productCommandService = new ProductCommandService(_productRepository.Object, _logger.Object);

            // Act
            productCommandService.UpdateProduct(updatedProduct);

            // Assert
            _productRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void UpdateProductOption_PositiveScenario()
        {
            // Arrange
            var existingProductOption = new ProductOption
            {
                Id = 1,
                Code = "PO1",
                Description = "Description",
                ProductId = 1
            };

            var updatedProductOption = new ProductOption
            {
                Id = 1,
                Code = "PO2",
                Description = "New Description",
                ProductId = 1
            };

            _productRepository.Setup(x => x.GetProductOptionById(updatedProductOption.Id)).Returns(existingProductOption);
            var productCommandService = new ProductCommandService(_productRepository.Object, _logger.Object);

            // Act
            productCommandService.UpdateProductOption(updatedProductOption);

            // Assert
            _productRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void DeleteProduct_PositiveScenario()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Code = "Code",
                Description = "Description",
                Price = 10
            };

            _productRepository.Setup(x => x.GetProduct(product.Id)).Returns(product);
            var productCommandService = new ProductCommandService(_productRepository.Object, _logger.Object);

            // Act
            productCommandService.DeleteProduct(product.Id);

            // Assert
            _productRepository.Verify(x => x.Delete(product), Times.Once);
        }

        [Fact]
        public void DeleteProductOption_PositiveScenario()
        {
            // Arrange
            var productOption = new ProductOption
            {
                Id = 1,
                Code = "PO1",
                Description = "Description",
                ProductId = 1
            };

            _productRepository.Setup(x => x.GetProductOptionById(productOption.Id)).Returns(productOption);
            var productCommandService = new ProductCommandService(_productRepository.Object, _logger.Object);

            // Act
            productCommandService.DeleteProductOption(productOption.Id);

            // Assert
            _productRepository.Verify(x => x.DeleteProductOption(productOption), Times.Once);
        }

        [Fact]
        public void DeleteProductOptionsByProductId_PositiveScenario()
        {
            int productId = 1;

            // Arrange
            var productOptions = new List<ProductOption>
            {
                new ProductOption
                {
                    Id = 1,
                    Code = "PO1",
                    Description = "Product Option 1",
                    ProductId = productId
                },
                new ProductOption
                {
                    Id = 2,
                    Code = "PO2",
                    Description = "Product Option 2",
                    ProductId = productId
                }
            };

            _productRepository.Setup(x => x.GetProductOptionsByProductId(productId)).Returns(productOptions);
            var productCommandService = new ProductCommandService(_productRepository.Object, _logger.Object);

            // Act
            productCommandService.DeleteProductOptionsByProductId(productId);

            // Assert
            _productRepository.Verify(x => x.DeleteProductOptions(productOptions), Times.Once);
        }
    }
}
