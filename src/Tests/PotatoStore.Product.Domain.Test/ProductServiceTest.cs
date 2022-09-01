using FluentAssertions;
using Moq;
using Potato.Product.Domain.Aggregates.Products.Interfaces.Repositories;
using Potato.Product.Domain.Aggregates.Products.Services;
using PotatoStore.Base.Test;
using Xunit;

namespace Potato.Product.Domain.Test
{
    //Given_When_Should
    public class ProductServiceTest
    {
        public readonly ProductService _productService;

        private readonly Mock<IProductRepository> _productRepository;

        public ProductServiceTest()
        {
            _productRepository = new Mock<IProductRepository>();

            _productService = new ProductService(_productRepository.Object);
        }

        [Fact]
        public async Task UpdateAsync_When_Product_IsValid_ReturnProductUpdated()
        {
            //Arrange
            Aggregates.Products.Entities.Product productDto = new DataGenerator()
                .GenerateProductDto_Valid(1)
                .First();

            _productRepository.Setup(p => p
            .GetByIdAsync(
                It.IsAny<Guid>()))
                .ReturnsAsync(() => productDto);

            _productRepository.Setup(p => p
            .UpdateAsync(
                It.IsAny<Aggregates.Products.Entities.Product>()))
                .ReturnsAsync(() => productDto);

            //Act
            var item = await _productService.UpdateAsync(productDto.Id, productDto);

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

            _productRepository.Setup(p => p
            .GetByIdAsync(
                It.IsAny<Guid>()))
                .ReturnsAsync(() => default);

            //Act
            var item = await _productService.UpdateAsync(productDto.Id, productDto);

            //Assert
            item.Should().BeNull();
        }
    }
}