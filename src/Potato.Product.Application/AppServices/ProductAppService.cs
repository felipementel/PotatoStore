using Potato.Product.Application.Dtos;
using Potato.Product.Domain.Aggregates.Products.Services;

namespace Potato.Product.Application.AppServices
{
    public class ProductAppService
    {
        public async Task<ProductDto> InsertAsync(ProductDto productDto)
        {
            ProductServices productServices = new ProductServices();

            return await productServices.AddAsync(productDto);
        }
    }
}
