using Potato.Product.Domain.Aggregates.Products.Interfaces.Repositories;

namespace Potato.Product.Infra.Database.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<Domain.Aggregates.Products.Entities.Product> AddAsync(Domain.Aggregates.Products.Entities.Product product)
        {
            await _productContext.Products.AddAsync(product);
            await _productContext.SaveChangesAsync();

            return product;
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
