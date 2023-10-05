using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Write;

public class Cart : Entity
{
    #region Creation

    public Cart()
    { }

    public Cart(Domain.Cart cart) : base(cart.Id)
    {
        LineItems = cart.LineItems.Select(li => (CartLineItem) li).ToList();
        Subtotal = cart.Subtotal;
    }

    #endregion

    #region Public Interface

    public List<CartLineItem> LineItems { get; set; } = new();

    [Precision(6, 2)] 
    public decimal? Subtotal { get; set; }

    public Cart Update(Domain.Cart cart)
    {
        Subtotal = cart.Subtotal;

        foreach (var li in cart.LineItems.Select(li => new CartLineItem(li)))
            if (LineItems.All(x => x.Id != li.Id))
                LineItems.Add(li);

        return this;
    }
    #endregion

    #region Static Interface

    public static implicit operator Domain.Cart(Cart source) => new(source.Subtotal, source.Id);

    public static implicit operator Cart(Domain.Cart source) => new(source);

    #endregion
}