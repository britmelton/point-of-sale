namespace Domain;

public class LineItem : Entity
{
    public LineItem(Guid orderId, Product product, decimal price)
    {
        OrderId = orderId;
        ProductId = product.Id;
        Price = price;
        Subtotal = CalculateSubtotal();
    }

    public LineItem(Guid orderId, Guid productId, decimal price, ushort quantity, Guid id = default) : base(id)
    {
        OrderId = orderId;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
        Subtotal = CalculateSubtotal();
    }

    public void Deconstruct(out Guid productId, out decimal price, out ushort quantity)
    {
        productId = ProductId;
        price = Price;
        quantity = Quantity;
    }

    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public ushort Quantity { get; set; }
    public decimal Subtotal { get; set; }

    public decimal CalculateSubtotal()
    {
        Subtotal = Price * Quantity;
        return Subtotal;
    }
}