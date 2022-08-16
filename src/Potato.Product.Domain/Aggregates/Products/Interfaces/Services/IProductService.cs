﻿namespace Potato.Product.Domain.Aggregates.Products.Interfaces.Services
{
    public interface IProductService
    {
        Task<Entities.Product> AddAsync(Entities.Product product);

        Task<Entities.Product> GetByIdAsync(Guid productId);

        Task DeleteAsync(Guid productId);
        Task<bool> DeleteAsyncWithReturn(Guid productId);

        Task<IEnumerable<Entities.Product>> GetAllAsync();
    }
}