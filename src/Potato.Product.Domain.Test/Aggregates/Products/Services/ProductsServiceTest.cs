using FluentAssertions;
using Moq;
using Potato.Product.Domain.Aggregates.Products.Interfaces.Repositories;
using Potato.Product.Domain.Aggregates.Products.Services;

namespace Potato.Product.Domain.Test.Aggregates.Products.Services
{
    public class ProductsServiceTest
    {
        private readonly Mock<IProductRepository> _productRepository;

        public ProductsServiceTest()
        {
            _productRepository = new Mock<IProductRepository>();
        }

        [Fact]
        public async Task Should_Returns_Product_List()
        {
            //Arrenge
            var products = new List<Domain.Aggregates.Products.Entities.Product>()
            {
                new (Guid.NewGuid(), "Geladeira", "Geladeira 410L", "SKU012", 3000)
            };

            _productRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productService = new ProductService(_productRepository.Object);

            //Act
            var result = await productService.GetAllAsync();

            //Assert
            _productRepository.Verify(x => x.GetAllAsync(), Times.Once());
            result.ToList().Count.Should().Be(1);
        }

        [Fact]
        public async Task Should_Returns_Product_List_Empty()
        {
            //Arrenge
            var products = new List<Domain.Aggregates.Products.Entities.Product>(){};

            _productRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            var productService = new ProductService(_productRepository.Object);

            //Act
            var result = await productService.GetAllAsync();

            //Assert
            _productRepository.Verify(x => x.GetAllAsync(), Times.Once());
            result.ToList().Count.Should().Be(0);
        }
    }
}
