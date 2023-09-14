namespace Infrastructure.Read
{
    public class LineItem
    {
        public Guid Id { get; init; }
        public Guid OrderId { get; init; }
        public Guid ProductId { get; init; }
        public decimal Price { get; init; }
        public ushort Quantity { get; init; }
    }

    public class LineItemDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public ushort Quantity { get; set; }
    }
}
