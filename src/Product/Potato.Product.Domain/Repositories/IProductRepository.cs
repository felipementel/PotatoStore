namespace Potato.Product.Domain.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(Guid id);
        Product GetById(Guid id);
        IEnumerable<Product> GetAll();
    }
}
