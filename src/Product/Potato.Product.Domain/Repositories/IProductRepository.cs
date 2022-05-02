namespace Potato.Product.Domain.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Guid id,Product product);
        void Remove(Guid id);
        Product GetById(Guid id);
        IEnumerable<Product> GetAll();
    }
}
