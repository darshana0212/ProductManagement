using FluentAssertions;
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
    public class ProductQueryServiceTests
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<ILogger<ProductQueryService>> _logger;

        public ProductQueryServiceTests()
        {
            _productRepository = new Mock<IProductRepository>();
            _logger = new Mock<ILogger<ProductQueryService>>();
        }

        [Fact]
        public void GetProductById_PositiveScenario()
        {
            // Arrange
            var expectedProduct = new Product
            {
                Id = 1,
                Code = "Code",
                Description = "Description",
                Price = 10,
                ProductOptions = new List<ProductOption> {
                    new ProductOption { Id = 1, Code = "ProductOptionCode", Description = "ProductOption Description", ProductId = 1 }
                }
            };

            _productRepository.Setup(x => x.GetProduct(It.IsAny<int>())).Returns(expectedProduct);
            var productQueryService = new ProductQueryService(_productRepository.Object, _logger.Object);

            // Act
            var actualProduct = productQueryService.GetProduct(It.IsAny<int>());
            
            // Assert
            _productRepository.Verify(x => x.GetProduct(It.IsAny<int>()), Times.Once);
            actualProduct.Should().BeEquivalentTo(expectedProduct);
        }

        [Fact]
        public void GetProductOptionById_PositiveScenario()
        {
            // Arrange
            var expectedProductOptions = new List<ProductOption>
            {
                new ProductOption
                {
                    Id = 1,
                    Code = "PO1",
                    Description = "Product Option 1",
                    ProductId = 1
                },
                new ProductOption
                {
                    Id = 2,
                    Code = "PO2",
                    Description = "Product Option 2",
                    ProductId = 1
                }
            };

            _productRepository.Setup(x => x.GetProductOptionsByProductId(It.IsAny<int>())).Returns(expectedProductOptions);
            var productQueryService = new ProductQueryService(_productRepository.Object, _logger.Object);

            // Act
            var actualProductOptions = productQueryService.GetProductOptionsByProductId(It.IsAny<int>());
            
            // Assert
            _productRepository.Verify(x => x.GetProductOptionsByProductId(It.IsAny<int>()), Times.Once);
            actualProductOptions.Should().BeEquivalentTo(expectedProductOptions);
        }

        [Fact]
        public void GetProductOptionById_ThrowsException()
        {
            // Arrange
            _productRepository.Setup(x => x.GetProductOptionsByProductId(It.IsAny<int>())).Throws(new Exception("An error occurred while retrieving Product Options"));
            var productQueryService = new ProductQueryService(_productRepository.Object, _logger.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => productQueryService.GetProductOptionsByProductId(It.IsAny<int>()));
        }

        [Fact]
        public void GetProducts_PositiveScenario()
        {
            // Arrange
            var expectedProducts = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Code = "Code",
                    Description = "Description",
                    Price = 10,
                    ProductOptions = new List<ProductOption> {
                        new ProductOption { Id = 1, Code = "ProductOptionCode", Description = "ProductOption Description", ProductId = 1 }
                    }
                }
            };

            _productRepository.Setup(x => x.GetAllProducts()).Returns(expectedProducts);
            var productQueryService = new ProductQueryService(_productRepository.Object, _logger.Object);

            // Act
            var actualProducts = productQueryService.GetProducts();
            
            // Assert
            _productRepository.Verify(x => x.GetAllProducts(), Times.Once);
            actualProducts.Should().BeEquivalentTo(expectedProducts);
        }

        [Fact]
        public void GetProducts_ThrowsException()
        {
            // Arrange
            _productRepository.Setup(x => x.GetAllProducts()).Throws(new Exception("An error occurred while retrieving Products"));
            var productQueryService = new ProductQueryService(_productRepository.Object, _logger.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => productQueryService.GetProducts());
        }
    }
}
