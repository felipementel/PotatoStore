using Microsoft.EntityFrameworkCore;
using Potato.Product.Infra.Database.Configurations;

namespace Potato.Product.Infra.Database
{
    public class ProductContext : DbContext
    {
        public DbSet<Domain.Aggregates.Products.Entities.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProductsEntityTypeConfiguration().Configure(modelBuilder.Entity<Domain.Aggregates.Products.Entities.Product>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql($"Username=user01;Password=example;Host=localhost;Port=5432;Database=PotatoDatabase;");
    }
}
