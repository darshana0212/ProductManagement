using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductManagement.Api.Controllers;
using ProductManagement.Data;
using ProductManagement.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProductManagement.Api.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductCommandService> _productCommandService;
        private readonly Mock<IProductQueryService> _productQueryService;

        public ProductControllerTests()
        {
            _productCommandService = new Mock<IProductCommandService>();
            _productQueryService = new Mock<IProductQueryService>();
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

            _productQueryService.Setup(x => x.GetProduct(It.IsAny<int>())).Returns(expectedProduct);
            var productController = new ProductController(_productCommandService.Object, _productQueryService.Object);
            
            // Act
            IActionResult result = productController.GetProductById(It.IsAny<int>());
            var actualProduct = ((OkObjectResult)result).Value as Product;

            // Assert
            _productQueryService.Verify(x => x.GetProduct(It.IsAny<int>()), Times.Once);
            Assert.IsType<OkObjectResult>(result);
            actualProduct.Should().BeEquivalentTo(expectedProduct);
        }

        [Fact]
        public void GetProductById_ThrowsException()
        {
            // Arrange
            _productQueryService.Setup(x => x.GetProduct(It.IsAny<int>())).Throws(new Exception("An error occurred while retrieving Products"));
            var productController = new ProductController(_productCommandService.Object, _productQueryService.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => productController.GetProductById(It.IsAny<int>()));
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
        
            _productQueryService.Setup(x => x.GetProducts()).Returns(expectedProducts);
            var productController = new ProductController(_productCommandService.Object, _productQueryService.Object);

            // Act
            IActionResult result = productController.GetProducts();
            var actualProducts = ((OkObjectResult)result).Value as List<Product>;

            // Assert
            _productQueryService.Verify(x => x.GetProducts(), Times.Once);
            Assert.IsType<OkObjectResult>(result);
            actualProducts.Should().BeEquivalentTo(expectedProducts);
        }

        [Fact]
        public void GetProducts_ThrowsException()
        {
            // Arrange
            _productQueryService.Setup(x => x.GetProducts()).Throws(new Exception("An error occurred while retrieving Products"));
            var productController = new ProductController(_productCommandService.Object, _productQueryService.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => productController.GetProducts());
        }

        [Fact]
        public void AddProduct_PositiveScenario()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Code = "Code",
                Description = "Description",
                Price = 10
            };

            _productCommandService.Setup(x => x.SaveProduct(product)).Returns(product.Id);
            var productController = new ProductController(_productCommandService.Object, _productQueryService.Object);

            // Act
            IActionResult result = productController.AddProduct(product);

            // Assert
            _productCommandService.Verify(x => x.SaveProduct(product), Times.Once);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void AddProduct_ThrowsException()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Code = "Code",
                Description = "Description",
                Price = 10
            };

            _productCommandService.Setup(x => x.SaveProduct(product)).Throws(new Exception("An error occurred while adding new Product"));
            var productController = new ProductController(_productCommandService.Object, _productQueryService.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => productController.AddProduct(product));
        }

        [Fact]
        public void UpdateProduct_PositiveScenario()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Code = "Code",
                Description = "Description",
                Price = 10
            };

            _productCommandService.Setup(x => x.UpdateProduct(product));
            var productController = new ProductController(_productCommandService.Object, _productQueryService.Object);

            // Act
            IActionResult result = productController.UpdateProduct(product.Id, product);

            // Assert
            _productCommandService.Verify(x => x.UpdateProduct(product), Times.Once);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UpdateProduct_ThrowsException()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Code = "Code",
                Description = "Description",
                Price = 10
            };

            _productCommandService.Setup(x => x.UpdateProduct(product)).Throws(new Exception("An error occurred while updating Product"));
            var productController = new ProductController(_productCommandService.Object, _productQueryService.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => productController.UpdateProduct(product.Id, product));
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

            _productCommandService.Setup(x => x.DeleteProduct(product.Id));
            var productController = new ProductController(_productCommandService.Object, _productQueryService.Object);

            // Act
            IActionResult result = productController.DeleteProduct(product.Id);

            // Assert
            _productCommandService.Verify(x => x.DeleteProduct(product.Id), Times.Once);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteProduct_ThrowsException()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Code = "Code",
                Description = "Description",
                Price = 10
            };

            _productCommandService.Setup(x => x.DeleteProduct(product.Id)).Throws(new Exception("An error occurred while deleting Product"));
            var productController = new ProductController(_productCommandService.Object, _productQueryService.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => productController.DeleteProduct(product.Id));
        }
    }
}
