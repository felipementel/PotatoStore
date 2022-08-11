namespace Potato.Product.Domain.Aggregates.Products.Interfaces.Services
{
    public interface IProductService
    {
        Task<Entities.Product> AddAsync(Entities.Product product);

        Task<Entities.Product> GetByIdAsync(Guid productId);

        Task<Entities.Product> UpdateAsync(Guid productId, Entities.Product product);
    }
}