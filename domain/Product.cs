namespace Domain
{
    public class Product : Entity
    {
        public Product(string name, decimal price, string sku, ushort quantityOnHand = default, Guid id = default) : this(id)
        {
            Name = name;
            Price = price;
            Sku = sku;
            QuantityOnHand = quantityOnHand;
        }

        public Product(Guid id = default) : base(id)
        {

        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ushort QuantityOnHand { get; set; }
        public string Sku { get; set; }

    }
}