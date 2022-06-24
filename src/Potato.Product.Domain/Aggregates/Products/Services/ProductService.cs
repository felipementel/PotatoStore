using Potato.Product.Domain.Aggregates.Products.Interfaces.Repositories;
using Potato.Product.Domain.Aggregates.Products.Interfaces.Services;

namespace Potato.Product.Domain.Aggregates.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Entities.Product> AddAsync(Entities.Product product)
        {
            return await _productRepository.AddAsync(product);
        }
    }
}
