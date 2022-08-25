using FluentAssertions;
using Moq;
using Potato.Product.Domain.Aggregates.Products.Interfaces.Repositories;
using Potato.Product.Domain.Aggregates.Products.Services;
using Xunit;

namespace Potato.Product.Domain.Test.Aggregates.Products.Services
{
    public class ProductsServiceTest
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;

        public ProductsServiceTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
        }

        [Fact]
        public async Task GetAllAsync_HaveProducts_ReturnsProductList()
        {
            //Arrenge
            var products = new List<Domain.Aggregates.Products.Entities.Product>()
            {
                new (Guid.NewGuid(), "Geladeira", "Geladeira 410L", "SKU012", 3000)
            };

            _productRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productService = new ProductService(_productRepositoryMock.Object);

            //Act
            var result = await productService.GetAllAsync();

            //Assert
            _productRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once());
            result.ToList().Count.Should().Be(1);
        }

        [Fact]
        public async Task GetAllAsync_IfProductsLisEmpty_ReturnsProductListEmpty()
        {
            //Arrenge
            var products = new List<Domain.Aggregates.Products.Entities.Product>(){};

            _productRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productService = new ProductService(_productRepositoryMock.Object);

            //Act
            var result = await productService.GetAllAsync();

            //Assert
            _productRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once());
            result.ToList().Count.Should().Be(0);
        }
    }
}
