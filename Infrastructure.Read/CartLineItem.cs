namespace Infrastructure.Read;

public class CartLineItem
{
    public Guid Id { get; init; }
    public Guid CartId { get; init; }
    public Guid ProductId { get; init; }
    public decimal Price { get; init; }
    public ushort Quantity { get; init; }
    public decimal? Subtotal { get; init; }
}

public class CartLineItemDto
{
    public CartLineItemDto(Guid id, Guid cartId, Guid productId, decimal price, ushort quantity, decimal? subtotal)
    {
        Id = id;
        CartId = cartId;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
        Subtotal = subtotal;
    }

    public CartLineItemDto(CartLineItem source) : this(
        source.Id,
        source.CartId,
        source.ProductId,
        source.Price,
        source.Quantity,
        source.Subtotal
    )
    { }

    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public ushort Quantity { get; set; }
    public decimal? Subtotal { get; set; }

    public static implicit operator CartLineItemDto(CartLineItem source) => new(source);
}