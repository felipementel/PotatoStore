﻿using Potato.Product.Application.Dtos;
using Potato.Product.Application.Interfaces.Services;
using Potato.Product.Domain.Aggregates.Products.Interfaces.Services;
using System.Linq;

namespace Potato.Product.Application.AppServices
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productServices;

        public ProductAppService(IProductService productServices)
        {
            _productServices = productServices;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var retorno = await _productServices.GetAllAsync();

            return retorno.Select<Domain.Aggregates.Products.Entities.Product, ProductDto>(x => x).ToList();

            //return retorno.Select(p => (ProductDto)p).ToList();
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


    }
}
