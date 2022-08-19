namespace Potato.Product.Domain.Aggregates.Products.Entities
{
    public record class Product
    {
        public Product(
            Guid id,
            string name,
            string description,
            //URL url,
            string sKU,
            decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            //this.url = url;
            SKU = sKU;
            Price = price;
            OnCreated = DateOnly.FromDateTime(DateTime.UtcNow);
            OnModified = DateTime.UtcNow;
        }

        public Guid Id { get; init; }

        public string Name { get; init; }

        public string Description { get; init; }
        
        //public URL url { get; init; }

        public string SKU { get; init; }

        public decimal Price { get; init; }

        public DateOnly OnCreated { get; set; }

        public DateTime OnModified { get; set; }
    }
}