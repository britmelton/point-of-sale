using System.Security.Cryptography;

namespace domain
{
    public class Order
    {
        public Guid Id { get; }
        public string OrderNumber { get; }

        public Order(string? orderNumber = default, Guid id = default)
        {
            OrderNumber = orderNumber == default ? GenerateOrderNumber() : orderNumber;
            Id = id == default ? Guid.NewGuid() : id;
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
