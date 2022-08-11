namespace Potato.Product.Domain.Aggregates.Products.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Entities.Product> AddAsync(Entities.Product product);

        Task<Entities.Product> UpdateAsync(Entities.Product product);

        Task RemoveAsync(Guid id);

        Task<Entities.Product> GetByIdAsync(Guid id);

        Task<IEnumerable<Entities.Product>> GetAllAsync();
    }
}