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
            var item = await _productContext.Products?.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id)!;

            return item!;

           
        }

        public async Task RemoveAsync(Potato.Product.Domain.Aggregates.Products.Entities.Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
        }

        public async Task<Domain.Aggregates.Products.Entities.Product> UpdateAsync(Domain.Aggregates.Products.Entities.Product product)
        {
            _productContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _productContext.SaveChangesAsync();

            return product;
        }

        public async Task<Domain.Aggregates.Products.Entities.Product> PatchAsync(Guid id, Domain.Aggregates.Products.Entities.Product product)
        {
            _productContext.Products.Update(product);
            await _productContext.SaveChangesAsync();

            return product;
        }
    }
}
