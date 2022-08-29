using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Potato.Product.Api.Controllers;
using Potato.Product.Application.Dtos;
using Potato.Product.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Potato.Product.Api.Test.Controllers
{
    public class ProductControllerTest
    {
        private readonly Mock<ILogger<ProductController>> _loggerMock;
        public readonly Mock<IProductAppService> _productAppServiceMock;

        public ProductControllerTest()
        {
            _loggerMock = new Mock<ILogger<ProductController>>();
            _productAppServiceMock = new Mock<IProductAppService>();
        }

        [Fact]
        public async Task GetAllAsync_HaveItems_ReturnAllItems()
        {
            //Arrenge
            var products = new List<ProductDto>()
            {
                new (Guid.NewGuid(), "Geladeira", "Geladeira 410L", "SKU012", 3000,DateOnly.FromDateTime(DateTime.UtcNow),DateTime.UtcNow),
                new (Guid.NewGuid(), "Fogao", "Fogao 4 bocas", "SKU013", 556.50M,DateOnly.FromDateTime(DateTime.UtcNow),DateTime.UtcNow)
            };
            _productAppServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productAppService = new ProductController(_loggerMock.Object, _productAppServiceMock.Object);

            //Act
            var result = await productAppService.GetAllAsync();

            //Assert
            result.As<OkObjectResult>().Value.Should().BeOfType<List<ProductDto>>();
            result.As<OkObjectResult>().Value.As<List<ProductDto>>().Count.Should().Be(2);
        }

        [Fact]
        public async Task GetAllAsync_HaveItems_ReturnStatus200Ok()
        {
            //Arrenge
            var products = new List<ProductDto>()
            {
                new (Guid.NewGuid(), "Geladeira", "Geladeira 410L", "SKU012", 3000,DateOnly.FromDateTime(DateTime.UtcNow),DateTime.UtcNow),
                new (Guid.NewGuid(), "Fogao", "Fogao 4 bocas", "SKU013", 556.50M,DateOnly.FromDateTime(DateTime.UtcNow),DateTime.UtcNow)
            };
            _productAppServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productAppService = new ProductController(_loggerMock.Object, _productAppServiceMock.Object);

            //Act
            var result = await productAppService.GetAllAsync();

            //Assert
            result.As<OkObjectResult>().StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetAllAsync_HasNoItems_ReturnStatus404NotFound()
        {
            //Arrenge
            var products = new List<ProductDto>() { };
            _productAppServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productAppService = new ProductController(_loggerMock.Object, _productAppServiceMock.Object);

            //Act
            var result = await productAppService.GetAllAsync();

            //Assert
            result.As<NotFoundResult>().StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}
