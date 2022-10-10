using Microsoft.Extensions.DependencyInjection;
using Potato.Product.Application.AppServices;
using Potato.Product.Application.Interfaces.Services;
using Potato.Product.Domain.Aggregates.Products.Interfaces.Repositories;
using Potato.Product.Domain.Aggregates.Products.Interfaces.Services;
using Potato.Product.Domain.Aggregates.Products.Services;
using Potato.Product.Infra.Database.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace Potato.Product.Infra.CrossCutting;

[ExcludeFromCodeCoverage]
public static class IoC
{
    public static void AddDependeciesInjections(this IServiceCollection Services)
    {
        //IoC
        Services.AddScoped<IProductRepository, ProductRepository>();
        Services.AddScoped<IProductAppService, ProductAppService>();
        Services.AddScoped<IProductService, ProductService>();
    }
}