using Potato.Product.Domain.Aggregates.Products.Interfaces.Repositories;

namespace Potato.Product.Infra.Database.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task AddAsync(Domain.Aggregates.Products.Entities.Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Aggregates.Products.Entities.Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Aggregates.Products.Entities.Product> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, Domain.Aggregates.Products.Entities.Product product)
        {
            throw new NotImplementedException();
        }
    }
}
