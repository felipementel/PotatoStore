using Microsoft.EntityFrameworkCore;
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
            await _productContext.Products!.AddAsync(product);
            await _productContext.SaveChangesAsync();

            return product;
        }

        public async Task<IEnumerable<Domain.Aggregates.Products.Entities.Product>> GetAllAsync()
        {
            return await _productContext.Products?.ToListAsync()!;
        }

        public async Task<Domain.Aggregates.Products.Entities.Product> GetByIdAsync(Guid id)
        {
            var item = await _productContext.Products?.FirstOrDefaultAsync(p => p.Id == id)!;

            if(item != null)
            {
                _productContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }

            return item!;

            //TODO (Luis): Revisar metodo assincrono
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, Domain.Aggregates.Products.Entities.Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Aggregates.Products.Entities.Product> PartialUpdateAsync(Guid id, Domain.Aggregates.Products.Entities.Product product)
        {
            _productContext.Products.Update(product);
            await _productContext.SaveChangesAsync();

            return product;
        }
    }
}
