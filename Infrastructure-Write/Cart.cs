using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Write;

public class Cart : Entity
{
    #region Creation

    public Cart()
    {
    }

    public Cart(Domain.Cart cart) : base(cart.Id)
    {
        LineItems = cart.LineItems.Select(li => (CartLineItem) li).ToList();
        Subtotal = cart.Subtotal;
    }

    #endregion

    #region Public Interface

    public List<CartLineItem>? LineItems { get; set; }

    [Precision(6, 2)] public decimal? Subtotal { get; set; }

    public Cart Update(Domain.Cart cart)
    {
        LineItems.AddRange(cart.LineItems.Select(li => (CartLineItem) li));
        foreach (var li in LineItems)
        {
            li.CartId = cart.Id;
        }

        Subtotal = cart.Subtotal;

        return this;
    }

    #endregion

    #region Static Interface

    public static implicit operator Domain.Cart(Cart source) => new(source.Subtotal, source.Id);

    public static implicit operator Cart(Domain.Cart source) => new(source);

    #endregion
}
