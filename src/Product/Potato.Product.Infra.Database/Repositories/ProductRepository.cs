using Potato.Product.Domain.Repositories;

namespace Potato.Product.Infra.Database.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task AddAsync(Domain.Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Product> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, Domain.Product product)
        {
            throw new NotImplementedException();
        }
    }
}
