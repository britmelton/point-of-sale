using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Write;

public class CartLineItem : Entity
{
    public CartLineItem() { }
    public CartLineItem(Domain.CartLineItem lineItem) : base(lineItem.Id)
    {
        Price = lineItem.Price;
        ProductId = lineItem.ProductId;
        Quantity = lineItem.Quantity;
        Subtotal = lineItem.Subtotal;
    }

    public Guid CartId { get; set; }

    [Precision(6, 2)]
    public decimal Price { get; set; }
    public Guid ProductId { get; set; }
    public ushort Quantity { get; set; }
    [Precision(6, 2)]
    public decimal Subtotal { get; set; }


    public static implicit operator Domain.CartLineItem(CartLineItem source) => new(source.ProductId, source.Price, source.Quantity, source.Id);

    public static implicit operator CartLineItem(Domain.CartLineItem source) => new(source);
}