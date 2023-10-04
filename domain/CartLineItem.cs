namespace Domain;

public class CartLineItem : Entity
{
    public CartLineItem(Product product, decimal price)
    {
        ProductId = product.Id;
        Price = price;
        Subtotal = CalculateSubtotal();
    }

    public CartLineItem(Guid productId, decimal price, ushort quantity, Guid id = default) : base(id)
    {
        ProductId = productId;
        Price = price;
        Quantity = quantity;
        Subtotal = CalculateSubtotal();
    }

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