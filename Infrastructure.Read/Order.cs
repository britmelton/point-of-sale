namespace Infrastructure.Read
{
    public class Order //reps order Table
    {
        public Guid Id { get; init; } //allows you to do the object initialization 
        public bool IsComplete { get; init; }
        public string OrderNumber { get; init; }
        public decimal Subtotal { get; init; }
        public decimal Total { get; init; }
    }

    public class OrderDto
    {
        public Guid Id { get; set; }
        public bool IsComplete { get; set; }
        public List<LineItemDto> LineItems { get; set; } = new();
        public string OrderNumber { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}