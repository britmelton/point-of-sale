namespace domain
{
    public class Product
    {
        public string Name { get; set; }
        public string Sku { get; set; }

        public Product(string name, string sku)
        {
            Name = name;
            Sku = sku;
        }
    }
}
