namespace Potato.Product.Domain.Aggregates.Products.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Entities.Product> AddAsync(Entities.Product product);

        Task UpdateAsync(Guid id, Entities.Product product);

        Task RemoveAsync(Entities.Product product);

        Task<Entities.Product> GetByIdAsync(Guid id);

        Task<IEnumerable<Entities.Product>> GetAllAsync();
    }
}