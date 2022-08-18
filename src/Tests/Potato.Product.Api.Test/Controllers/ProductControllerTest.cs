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
    public  class ProductControllerTest
    {
        private readonly Mock<ILogger<ProductController>> _logger;
        public readonly Mock<IProductAppService> _productAppService;

        public ProductControllerTest()
        {
            _logger = new Mock<ILogger<ProductController>>();
            _productAppService = new Mock<IProductAppService>();
        }

        [Fact]
        public async Task Should_Return_All_Items() 
        {
            //Arrenge
            var products = new List<ProductDto>()
            {
                new (Guid.NewGuid(), "Geladeira", "Geladeira 410L", "SKU012", 3000,DateOnly.FromDateTime(DateTime.UtcNow),DateTime.UtcNow),
                new (Guid.NewGuid(), "Fogao", "Fogao 4 bocas", "SKU013", 556.50M,DateOnly.FromDateTime(DateTime.UtcNow),DateTime.UtcNow)
            };
            _productAppService.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productAppService = new ProductController(_logger.Object, _productAppService.Object);

            //Act
            var result = await productAppService.GetAllAsync();

            //Assert
            result.As<OkObjectResult>().Value.Should().BeOfType<List<ProductDto>>();
            result.As<OkObjectResult>().Value.As<List<ProductDto>>().Count().Should().Be(2);
        }

        [Fact]
        public async Task Should_Return_Status_200Ok()
        {
            //Arrenge
            var products = new List<ProductDto>()
            {
                new (Guid.NewGuid(), "Geladeira", "Geladeira 410L", "SKU012", 3000,DateOnly.FromDateTime(DateTime.UtcNow),DateTime.UtcNow),
                new (Guid.NewGuid(), "Fogao", "Fogao 4 bocas", "SKU013", 556.50M,DateOnly.FromDateTime(DateTime.UtcNow),DateTime.UtcNow)
            };
            _productAppService.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productAppService = new ProductController(_logger.Object, _productAppService.Object);

            //Act
            var result = await productAppService.GetAllAsync();

            //Assert
            result.As<OkObjectResult>().StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task Should_Return_Status_404NotFound()
        {
            //Arrenge
            var products = new List<ProductDto>(){};
            _productAppService.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productAppService = new ProductController(_logger.Object, _productAppService.Object);

            //Act
            var result = await productAppService.GetAllAsync();

            //Assert
            result.As<NotFoundResult>().StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}
