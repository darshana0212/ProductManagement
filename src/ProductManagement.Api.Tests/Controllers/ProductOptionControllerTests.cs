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
    public class ProductOptionControllerTests
    {
        private readonly Mock<IProductCommandService> _productCommandService;
        private readonly Mock<IProductQueryService> _productQueryService;

        public ProductOptionControllerTests()
        {
            _productCommandService = new Mock<IProductCommandService>();
            _productQueryService = new Mock<IProductQueryService>();
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

            _productQueryService.Setup(x => x.GetProductOptionsByProductId(It.IsAny<int>())).Returns(expectedProductOptions);
            var productOptionController = new ProductOptionController(_productCommandService.Object, _productQueryService.Object);

            // Act
            IActionResult result = productOptionController.GetProductOptionsByProductId(It.IsAny<int>());
            var actualProductOptions = ((OkObjectResult)result).Value as List<ProductOption>;

            // Assert
            _productQueryService.Verify(x => x.GetProductOptionsByProductId(It.IsAny<int>()), Times.Once);
            Assert.IsType<OkObjectResult>(result);
            actualProductOptions.Should().BeEquivalentTo(expectedProductOptions);
        }

        [Fact]
        public void GetProductOptionById_ThrowsException()
        {
            // Arrange
            _productQueryService.Setup(x => x.GetProductOptionsByProductId(It.IsAny<int>())).Throws(new Exception("An error occurred while retrieving Product Options"));
            var productOptionController = new ProductOptionController(_productCommandService.Object, _productQueryService.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => productOptionController.GetProductOptionsByProductId(It.IsAny<int>()));
        }

        [Fact]
        public void AddProductOption_PositiveScenario()
        {
            // Arrange
            var productOption = new ProductOption
            {
                Id = 1,
                Code = "PO1",
                Description = "Description",
                ProductId = 1
            };

            _productCommandService.Setup(x => x.SaveProductOption(productOption)).Returns(productOption.Id);
            var productOptionController = new ProductOptionController(_productCommandService.Object, _productQueryService.Object);

            // Act
            IActionResult result = productOptionController.AddProductOption(productOption);

            // Assert
            _productCommandService.Verify(x => x.SaveProductOption(productOption), Times.Once);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void AddProductOption_ThrowsException()
        {
            // Arrange
            var productOption = new ProductOption
            {
                Id = 1,
                Code = "PO1",
                Description = "Description",
                ProductId = 1
            };

            _productCommandService.Setup(x => x.SaveProductOption(productOption)).Throws(new Exception("An error occurred while adding new Product Option"));
            var productOptionController = new ProductOptionController(_productCommandService.Object, _productQueryService.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => productOptionController.AddProductOption(productOption));
        }

        [Fact]
        public void UpdateProductOption_PositiveScenario()
        {
            // Arrange
            var productOption = new ProductOption
            {
                Id = 1,
                Code = "PO1",
                Description = "Description",
                ProductId = 1
            };

            _productCommandService.Setup(x => x.UpdateProductOption(productOption));
            var productOptionController = new ProductOptionController(_productCommandService.Object, _productQueryService.Object);

            // Act
            IActionResult result = productOptionController.UpdateProductOption(productOption.Id, productOption);

            // Assert
            _productCommandService.Verify(x => x.UpdateProductOption(productOption), Times.Once);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UpdateProduct_ThrowsException()
        {
            // Arrange
            var productOption = new ProductOption
            {
                Id = 1,
                Code = "PO1",
                Description = "Description",
                ProductId = 1
            };

            _productCommandService.Setup(x => x.UpdateProductOption(productOption)).Throws(new Exception("An error occurred while updating Product Option"));
            var productOptionController = new ProductOptionController(_productCommandService.Object, _productQueryService.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => productOptionController.UpdateProductOption(productOption.Id, productOption));
        }

        [Fact]
        public void DeleteProduct_PositiveScenario()
        {
            // Arrange
            var productOption = new ProductOption
            {
                Id = 1,
                Code = "PO1",
                Description = "Description",
                ProductId = 1
            };

            _productCommandService.Setup(x => x.DeleteProductOption(productOption.Id));
            var productOptionController = new ProductOptionController(_productCommandService.Object, _productQueryService.Object);

            // Act
            IActionResult result = productOptionController.DeleteProductOption(productOption.Id);

            // Assert
            _productCommandService.Verify(x => x.DeleteProductOption(productOption.Id), Times.Once);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteProduct_ThrowsException()
        {
            // Arrange
            var productOption = new ProductOption
            {
                Id = 1,
                Code = "PO1",
                Description = "Description",
                ProductId = 1
            };

            _productCommandService.Setup(x => x.DeleteProductOption(productOption.Id)).Throws(new Exception("An error occurred while deleting Product Option"));
            var productOptionController = new ProductOptionController(_productCommandService.Object, _productQueryService.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => productOptionController.DeleteProductOption(productOption.Id));
        }
    }
}
