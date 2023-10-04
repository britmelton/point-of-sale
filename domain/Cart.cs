namespace Domain;

public class Cart : Entity
{
    public Cart(decimal? subtotal = default, Guid id = default) : base(id)
    {
        Subtotal = subtotal;
        LineItems = new();
    }

    public List<CartLineItem>? LineItems { get; set; }
    public decimal? Subtotal { get; set; }


    public void AddLineItem(Guid productId, decimal price, ushort quantity)
    {
        var cartLineItem = new CartLineItem(productId, price, quantity);

        LineItems.Add(cartLineItem);

        CalculateSubtotal();
    }

    public void CalculateSubtotal()
    {
        foreach (var lineItem in LineItems)
        {
            lineItem.CalculateSubtotal();
        }
        var subtotal = LineItems.Sum(li => li.Subtotal);

        Subtotal = subtotal;
    }
}