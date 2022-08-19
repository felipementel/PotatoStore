using Potato.Product.Application.Dtos;

namespace Potato.Product.Application.Interfaces.Services
{
    public interface IProductAppService
    {
        Task<ProductDto> InsertAsync(ProductDto product);

        Task<ProductDto> GetByIdAsync(Guid productId);

        Task<ProductDto> PatchAsync(Guid id, ProductDto productDto);

        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<bool> DeleteAsync(Guid productId);

        Task<ProductDto> UpdateAsync(Guid productId, ProductDto product);
    }
}
