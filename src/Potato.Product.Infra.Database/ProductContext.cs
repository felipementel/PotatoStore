using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Potato.Product.Infra.Database.Configurations;

namespace Potato.Product.Infra.Database
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Domain.Aggregates.Products.Entities.Product>? Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProductsEntityTypeConfiguration().Configure(modelBuilder.Entity<Domain.Aggregates.Products.Entities.Product>());
            new UrlEntityTypeConfiguration().Configure(modelBuilder.Entity<Domain.Aggregates.Products.Entities.URL>());
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        { }
    }
}
