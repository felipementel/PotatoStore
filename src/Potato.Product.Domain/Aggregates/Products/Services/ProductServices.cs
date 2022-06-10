using Potato.Product.Domain.Aggregates.Products.Interfaces.Services;

namespace Potato.Product.Domain.Aggregates.Products.Services
{
    public class ProductServices : IProductService
    {
        public Task<Entities.Product> AddAsync(Entities.Product product)
        {
            throw new NotImplementedException();
        }
    }
}
