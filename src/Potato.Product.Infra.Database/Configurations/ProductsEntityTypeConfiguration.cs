using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Potato.Product.Infra.Database.Configurations
{
    internal class ProductsEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Aggregates.Products.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.Products.Entities.Product> builder)
        {
            builder
                .ToTable("Produto");

            builder
                .HasKey(c => c.Id);

            builder
                .Property<string>(c => c.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
