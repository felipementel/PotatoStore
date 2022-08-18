using Potato.Product.Application.Dtos;

namespace Potato.Product.Application.Interfaces.Services
{
    public interface IProductAppService
    {
        Task<ProductDto> InsertAsync(ProductDto product);

        Task<ProductDto> GetByIdAsync(Guid productId);

        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<bool> DeleteAsync(Guid productId);
    }
}
