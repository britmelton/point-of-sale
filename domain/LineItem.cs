namespace Domain;

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
    public decimal Total { get; set; }

    public decimal CalculateTotal()
    {
        Total = Price * Quantity;
        return Total;
    }
}