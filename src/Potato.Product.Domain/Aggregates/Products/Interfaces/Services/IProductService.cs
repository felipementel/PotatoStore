namespace Potato.Product.Domain.Aggregates.Products.Interfaces.Services
{
    public interface IProductService
    {
        Task<Entities.Product> AddAsync(Entities.Product product);

        Task<Entities.Product> GetByIdAsync(Guid productId);

        Task<bool> DeleteAsync(Guid productId);

        Task<IEnumerable<Entities.Product>> GetAllAsync();
    }
}