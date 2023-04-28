using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;

namespace domain
{
    public class Order
    {
        public Guid Id { get; }
        public string OrderNumber { get; }
        public List<Product> Products { get; set; }
        public decimal Subtotal { get; set; }


        public Order(string? orderNumber = default, Guid id = default)
        {
            Products = new();
            OrderNumber = orderNumber ?? GenerateOrderNumber();
            Id = id == default ? Guid.NewGuid() : id;
        }

        public void Add(Product product)
        {
            Products.Add(product);
            CalculateSubtotal();
        }

        public void CalculateSubtotal()
        {
            decimal subtotal = 0;

            foreach (var product in Products)
            {
                subtotal += product.Price;
            }
            
            Subtotal = subtotal;
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

        public void RemoveProduct(string sku)
        {
            _ = Products.Where(p => p.Sku == sku);

            foreach (var product in Products)
            {
                Products.Remove(product);
                Subtotal -= product.Price;
                break;
            }
        }
    }
}
