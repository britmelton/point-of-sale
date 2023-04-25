namespace domain
{
    public class Product
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }

        public Product(string name, decimal price, string sku, Guid id = default)
        {
            Name = name;
            Price = price;
            Sku = sku;
            Id = id == default ? Guid.NewGuid() : id;
        }
    }
}
