using System.Security.Cryptography;

namespace domain
{
    public class Order
    {
        public Guid Id { get; }
        public string OrderNumber { get; }
        public List<Product> Products { get; set; }

        public Order(string? orderNumber = default, Guid id = default)
        {
            Products = new();
            OrderNumber = orderNumber == default ? GenerateOrderNumber() : orderNumber;
            Id = id == default ? Guid.NewGuid() : id;
        }

        public void Add(Product product)
        {
            Products.Add(product);
        }

        private static string GenerateOrderNumber()
        {
            var randomNumber = new byte[4];
            var r = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                r = Convert.ToBase64String(randomNumber);
            }

            return $"ORD-{r}";
        }
    }
}
