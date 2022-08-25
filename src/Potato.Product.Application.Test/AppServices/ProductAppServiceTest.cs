using FluentAssertions;
using Moq;
using Potato.Product.Application.AppServices;
using Potato.Product.Domain.Aggregates.Products.Interfaces.Services;

namespace Potato.Product.Application.Test.AppServices
{
    public class ProductAppServiceTest
    {
        private readonly Mock<IProductService> _productServicesMock;

        public ProductAppServiceTest()
        {
            _productServicesMock = new Mock<IProductService>();
        }

        [Fact]
        public async Task GetAllAsync_HaveProducts_ReturnsProductsList()
        {
            //Arrenge
            var products = new List<Domain.Aggregates.Products.Entities.Product>()
            {
                new (Guid.NewGuid(), "Geladeira", "Geladeira 410L", "SKU012", 3000),
                new (Guid.NewGuid(), "Fogao", "Fogao 4 bocas", "SKU013", 556.50M)
            };

            _productServicesMock.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productAppService = new ProductAppService(_productServicesMock.Object);

            //Act
            var result = await productAppService.GetAllAsync();

            //Assert
            _productServicesMock.Verify(x => x.GetAllAsync(), Times.Once());
            result.ToList().Count.Should().Be(2);
        }

        [Fact]
        public async Task GetAllAsync_IfProductsListEmpty_ReturnsProductListEmpty()
        {
            //Arrenge
            var products = new List<Domain.Aggregates.Products.Entities.Product>() { };

            _productServicesMock.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productAppService = new ProductAppService(_productServicesMock.Object);

            //Act
            var result = await productAppService.GetAllAsync();

            //Assert
            _productServicesMock.Verify(x => x.GetAllAsync(), Times.Once());
            result.ToList().Count.Should().Be(0);
        }
    }
}
