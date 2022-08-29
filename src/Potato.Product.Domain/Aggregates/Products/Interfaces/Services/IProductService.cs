namespace Potato.Product.Domain.Aggregates.Products.Interfaces.Services
{
    public interface IProductService
    {
        Task<Entities.Product> AddAsync(Entities.Product product);

        Task<Entities.Product> GetByIdAsync(Guid productId);

        Task<Entities.Product> PatchAsync(Guid productId, Entities.Product product);

        Task<bool> DeleteAsync(Guid productId);

        Task<IEnumerable<Entities.Product>> GetAllAsync();

        Task<Entities.Product> UpdateAsync(Guid productId, Entities.Product product);
    }
}