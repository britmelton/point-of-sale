using System.Security.Cryptography;

namespace Domain
{
    public class Order : Entity
    {

        public Order(Guid id = default) : base(id)
        {
            OrderNumber = GenerateOrderNumber();
            LineItems = new();
        }
        public Order(List<LineItem> lineItems, string orderNumber, decimal subtotal, decimal total, Guid id = default) : base(id)
        {
            LineItems = lineItems;
            OrderNumber = orderNumber;
            Subtotal = subtotal;
            Total = total;
            OrderNumber = GenerateOrderNumber();
        }

        public Order(decimal subtotal, decimal total, Guid id = default) : base(id)
        {
            Subtotal = subtotal;
            Total = total;
            OrderNumber = GenerateOrderNumber();
            LineItems = new();
        }

        public bool IsComplete { get; set; }
        public string OrderNumber { get; }
        public List<LineItem> LineItems { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public void Add(LineItem lineItem)
        {
            LineItems.Add(lineItem);
            lineItem.Quantity++;

            CalculateSubtotal();
        }

        public void AddLineItem(Guid productId, ushort quantity, decimal price)
        {
            var lineItem = new LineItem(Id, productId, price, quantity);

            LineItems.Add(lineItem);

            CalculateSubtotal();
        }

        public void CalculateSubtotal()
        {
            var subtotal = LineItems.Sum(li => li.Price);

            Subtotal = subtotal;
        }

        private static string GenerateOrderNumber()
        {
            var random = new byte[4];
            var r = string.Empty;

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                r = Convert.ToBase64String(random);
            }

            return $"ORD-{r}";
        }

        public void RemoveProduct(Guid id)
        {
            var lineItem = LineItems.First(li => li.Id == id);

            LineItems.Remove(lineItem);
            Subtotal -= lineItem.Price;
        }

        public void Submit()
        {
            Total = Subtotal;
            IsComplete = true;
        }
    }
}