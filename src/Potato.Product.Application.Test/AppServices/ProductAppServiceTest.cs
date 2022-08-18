using FluentAssertions;
using Moq;
using Potato.Product.Application.AppServices;
using Potato.Product.Domain.Aggregates.Products.Interfaces.Services;

namespace Potato.Product.Application.Test.AppServices
{
    public class ProductAppServiceTest
    {
        private readonly Mock<IProductService> _productServices;

        public ProductAppServiceTest()
        {
            _productServices = new Mock<IProductService>();
        }

        [Fact]
        public async Task Should_Returns_Product_List()
        {
            //Arrenge
            var products = new List<Domain.Aggregates.Products.Entities.Product>()
            {
                new (Guid.NewGuid(), "Geladeira", "Geladeira 410L", "SKU012", 3000),
                new (Guid.NewGuid(), "Fogao", "Fogao 4 bocas", "SKU013", 556.50M)
            };

            _productServices.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productAppService = new ProductAppService(_productServices.Object);

            //Act
            var result = await productAppService.GetAllAsync();

            //Assert
            _productServices.Verify(x => x.GetAllAsync(), Times.Once());
            result.ToList().Count.Should().Be(2);
        }

        [Fact]
        public async Task Should_Returns_Product_List_Empty()
        {
            //Arrenge
            var products = new List<Domain.Aggregates.Products.Entities.Product>(){};

            _productServices.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productAppService = new ProductAppService(_productServices.Object);
            //Act
            var result = await productAppService.GetAllAsync();

            //Assert
            _productServices.Verify(x => x.GetAllAsync(), Times.Once());
            result.ToList().Count.Should().Be(0);
        }

    }
}
