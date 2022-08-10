using Potato.Product.Application.Dtos;
using Potato.Product.Application.Interfaces.Services;
using Potato.Product.Domain.Aggregates.Products.Interfaces.Services;

namespace Potato.Product.Application.AppServices
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productServices;

        public ProductAppService(IProductService productServices)
        {
            _productServices = productServices;
        }

        public async Task<ProductDto> GetByIdAsync(Guid productId)
        {
            var retorno = await _productServices.GetByIdAsync(productId);

            return retorno;
        }

        public async Task<ProductDto> InsertAsync(ProductDto productDto)
        {
            return await _productServices.AddAsync(productDto);
        }

        public async Task<ProductDto> PatchAsync(ProductDto productDto)
        {
            return await _productServices.PatchAsync(productDto);
        }
    }
}
