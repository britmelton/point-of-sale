namespace Infrastructure.Read
{
    public class Order
    {
        public Guid Id { get; init; }
        public bool IsComplete { get; init; }
        public List<LineItem> LineItems { get; init; }
        public string OrderNumber { get; init; }
        public decimal Subtotal { get; init; }
        public decimal Total { get; init; }
    }
}