using Potato.Product.Domain;

namespace Potato.Product.Application.Dtos
{
    public record ProductDto
    {
        public ProductDto(
            Guid id,
            string name,
            string description,
            //string url,
            string sKU,
            decimal price,
            DateOnly onCreated,
            DateTime onModified)
        {
            Id = id;
            Name = name;
            Description = description;
            //this.URL = url;
            SKU = sKU;
            Price = price;
            OnCreated = onCreated;
            OnModified = onModified;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //public string URL { get; set; }

        public string SKU { get; set; }

        public decimal Price { get; set; }

        public DateOnly OnCreated { get; set; }

        public DateTime OnModified { get; set; }

        public static implicit operator Domain.Aggregates.Products.Entities.Product(ProductDto dto) =>
            new(
                id: dto.Id,
                name: dto.Name,
                dto.Description,
                //url: new Domain.Aggregates.Products.Entities.URL(dto.URL),
                sKU: dto.SKU,
                price: dto.Price
                );

        public static implicit operator ProductDto(Domain.Aggregates.Products.Entities.Product entity) =>
            entity == null ? null :
            new(entity.Id,
                entity.Name,
                entity.Description,
                //entity.url.Endereco,
                entity.SKU,
                entity.Price,
                entity.OnCreated,
                entity.OnModified);
    }
}