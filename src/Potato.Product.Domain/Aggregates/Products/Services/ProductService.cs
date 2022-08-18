﻿using Potato.Product.Domain.Aggregates.Products.Interfaces.Repositories;
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

        public async Task<IEnumerable<Entities.Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Entities.Product> GetByIdAsync(Guid productId)
        {
            return await _productRepository.GetByIdAsync(productId);
        }

        public async Task<Entities.Product> PatchAsync(Guid id, Entities.Product product)
        {
            return await _productRepository.PartialUpdateAsync(id, product);
        }
    }
}
