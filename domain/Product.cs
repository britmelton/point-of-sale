namespace domain
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }

        public Product(string name, decimal price, string sku)
        {
            Name = name;
            Price = price;
            Sku = sku;
        }
    }
}
