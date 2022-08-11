using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Potato.Product.Infra.Database.Configurations
{
    internal class UrlEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Aggregates.Products.Entities.URL>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.Products.Entities.URL> builder)
        {
            builder
                .ToTable("Url").HasNoKey();
        }
    }
}
