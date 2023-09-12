namespace Domain
{
    public class LineItem : Entity
    {
        public LineItem(Guid orderId, Product product) : this(Guid.NewGuid(), orderId, product.Id, product.Price, product.QuantityOnHand)
        { }

        public LineItem(Guid id, Guid orderId, Guid productId, decimal price, ushort quantity) : base(id)
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