using FluentAssertions;
using Moq;
using Potato.Product.Domain.Aggregates.Products.Interfaces.Repositories;
using Potato.Product.Domain.Aggregates.Products.Services;
using PotatoStore.Base.Test;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Potato.Product.Domain.Test
{
    [ExcludeFromCodeCoverage]
    [Trait("Domain", "Service")]
    public class ProductServiceTest
    {
        public readonly ProductService _productService;

        private readonly Mock<IProductRepository> _productRepositoryMock;

        public ProductServiceTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();

            _productService = new ProductService(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task UpdateAsync_When_Product_IsValid_ReturnProductUpdated()
        {
            //Arrange
            Aggregates.Products.Entities.Product productDto = new DataGenerator()
                .GenerateProductDto_Valid(1)
                .First();

            _productRepositoryMock.Setup(p => p
            .GetByIdAsync(
                It.IsAny<Guid>()))
                .ReturnsAsync(() => productDto);

            _productRepositoryMock.Setup(p => p
            .UpdateAsync(
                It.IsAny<Aggregates.Products.Entities.Product>()))
                .ReturnsAsync(() => productDto);

            //Act
            Aggregates.Products.Entities.Product? item = await _productService.UpdateAsync(productDto.Id, productDto);

            //Assert
            item.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateAsync_When_Product_IsNotValid_ReturnNullProduct()
        {
            //Arrange
            Aggregates.Products.Entities.Product productDto = new DataGenerator()
                .GenerateProductDto_Valid(1)
                .First();

            _productRepositoryMock.Setup(p => p
            .GetByIdAsync(
                It.IsAny<Guid>()))
                .ReturnsAsync(() => default);

            //Act
            Aggregates.Products.Entities.Product? item = await _productService.UpdateAsync(productDto.Id, productDto);

            //Assert
            item.Should().BeNull();
        }
    }
}