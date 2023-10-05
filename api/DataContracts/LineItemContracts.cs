using App.Services;

namespace Api.DataContracts;

    public record LineItem(
        Guid ProductId,
        ushort Quantity,
        decimal Price
    )
    {
        public static implicit operator LineItem(App.Services.LineItem source) =>
        new(source.ProductId, source.Quantity, source.Price);

        public static implicit operator App.Services.LineItem(LineItem source) =>
            new(source.ProductId, source.Quantity, source.Price);
    }

public record AddLineItems(
    Guid CartId,
    List<CartLineItem> LineItems
)
{
    public static implicit operator AddLineItems(AddLineItemsCommand source) => new(source.CartId, source.LineItems.Select(li => (CartLineItem)li).ToList());

    public static implicit operator AddLineItemsCommand(AddLineItems source) =>
        new(source.CartId, source.LineItems.Select(li => (App.Services.CartLineItem)li).ToList());
}

public record CartLineItem(
    Guid CartId,
    Guid ProductId,
        ushort Quantity,
        decimal Price
)
    {
        public static implicit operator CartLineItem(App.Services.CartLineItem source) =>
        new(source.CartId, source.ProductId, source.Quantity, source.Price);

        public static implicit operator App.Services.CartLineItem(CartLineItem source) =>
        new(source.CartId, source.ProductId, source.Quantity, source.Price);
    }