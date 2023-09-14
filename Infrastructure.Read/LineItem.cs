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
}
