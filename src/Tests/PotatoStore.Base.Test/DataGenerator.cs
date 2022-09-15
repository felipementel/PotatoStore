using Bogus;
using Potato.Product.Application.Dtos;
using Potato.Product.Domain.Aggregates.Products.Entities;
using System.Diagnostics.CodeAnalysis;

namespace PotatoStore.Base.Test
{
    [ExcludeFromCodeCoverage]
    public class DataGenerator
    {
        public List<ProductDto> GenerateProductDto_Valid(int count)
        {
            return new Faker<ProductDto>(locale: "pt_BR")
                .StrictMode(false)
                .CustomInstantiator(p => new ProductDto(
                    p.Random.Guid(),
                    p.Commerce.ProductName(),
                    p.Commerce.ProductDescription(),
                    //p.Internet.Url(),
                    p.Random.Digits(6, 6).ToString(),
                    p.Random.Decimal(1, 5),
                    p.Date.RecentDateOnly(),
                    p.Date.Past()))
                .FinishWith((f, u) =>
                {
                    Console.WriteLine("ProductDto Created! Id={0}", u.Id);
                })
                .Generate(count);
        }

        public List<Product> GenerateProduct_Valid(int count)
        {
            return new Faker<Product>(locale: "pt_BR")
                .StrictMode(false)
                .CustomInstantiator(p => new Product(
                    p.Random.Guid(),
                    p.Commerce.ProductName(),
                    p.Commerce.ProductDescription(),
                    // new URL(p.Internet.Url()),
                    p.Random.Digits(6, 6).ToString(),
                    p.Random.Decimal(1, 5)))
                .FinishWith((f, u) =>
                {
                    Console.WriteLine("Product Created! Id={0}", u.Id);
                })
                .Generate(count);
        }
    }
}