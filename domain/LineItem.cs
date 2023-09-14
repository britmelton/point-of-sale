namespace Domain
{
    public class LineItem : Entity
    {
        public LineItem(Guid orderId, Product product, decimal price)
        {
            OrderId = orderId;
            ProductId = product.Id;
            Price = price;
        }

        public LineItem(Guid orderId, Guid productId, decimal price, ushort quantity, Guid id = default) : base(id)
        {
            OrderId = orderId;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public ushort Quantity { get; set; }
    }
}