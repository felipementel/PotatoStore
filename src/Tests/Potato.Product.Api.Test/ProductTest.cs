using Microsoft.Extensions.Logging;
using Moq;
using Potato.Product.Api.Controllers;
using Potato.Product.Application.Dtos;
using Potato.Product.Application.Interfaces.Services;
using PotatoStore.Base.Test;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Potato.Product.Api.Test;

//Given_When_Should

public class ProductTest
{
    private readonly Mock<ILogger<ProductsController>> _logger;

    public readonly Mock<IProductAppService> _productAppServiceMock;

    public ProductsController productController;

    public ProductTest()
    {
        _logger = new Mock<ILogger<ProductsController>>();
        _productAppServiceMock = new Mock<IProductAppService>();

        productController = new ProductsController(
            _logger.Object,
            _productAppServiceMock.Object);
    }

    [Fact]
    public async Task UpdateProduct_When_Product_IsValid_ShouldReturn200()
    {
        //Arrange
        ProductDto productDto = new DataGenerator()
            .GenerateProductDto_Valid(1)
            .First();

        var result = _productAppServiceMock.Setup(p => p
        .UpdateAsync(
            It.IsAny<Guid>(),
            It.IsAny<ProductDto>()))
        .ReturnsAsync(() => productDto);

        //Act
        var itemHttp = await productController
            .UpdateProductAsync(productDto.Id, productDto);

        //Assert
        _productAppServiceMock.Verify(p => p.UpdateAsync(It.IsAny<Guid>(),
            productDto), times: Times.Once);

        Assert.Equal(typeof(Microsoft.AspNetCore.Mvc.OkObjectResult), itemHttp.GetType());
    }

    [Fact]
    public async Task UpdateProduct_When_Product_IsNotValid_ShouldReturn404()
    {
        //Arrange
        ProductDto productDto = new DataGenerator()
            .GenerateProductDto_Valid(1)
            .First();

        var result = _productAppServiceMock.Setup(p => p
        .UpdateAsync(
            It.IsAny<Guid>(),
            It.IsAny<ProductDto>()))
        .ReturnsAsync(() => default);

        //Act
        var itemHttp = await productController
            .UpdateProductAsync(Guid.NewGuid(), productDto);

        //Assert
        _productAppServiceMock.Verify(p => p.UpdateAsync(It.IsAny<Guid>(),
            productDto), times: Times.Once);

        Assert.Equal(typeof(Microsoft.AspNetCore.Mvc.NotFoundResult), itemHttp.GetType());
    }
}