using Infrastructure.Read.Dtos;

namespace Infrastructure.Read;

public class Cart
{
    public Guid Id { get; init; }
    public decimal? Subtotal { get; init; }
}

public class CartDto
{
    private readonly List<CartLineItemDto> _lineItems = new();

    public CartDto(Guid id, decimal? subtotal)
    {
        Id = id;
        Subtotal = subtotal;
    }

    public CartDto(Cart cart) : this(cart.Id, cart.Subtotal)
    { }

    public Guid Id { get; }
    public IReadOnlyList<CartLineItemDto> LineItems => _lineItems.AsReadOnly();
    public decimal? Subtotal { get; }

    public void Add(CartLineItemDto lineItem)
    {
        _lineItems.Add(lineItem);
    }

    public static implicit operator CartDto(Cart cart) => new(cart);
}