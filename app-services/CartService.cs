using Domain;

namespace App.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public Cart Add(AddLineItemsCommand args)
    {
        var cart = _cartRepository.Find(args.CartId);
        foreach (var item in args.LineItems)
        {
            cart.AddLineItem(item.ProductId, item.Price, item.Quantity);
        }
        _cartRepository.Update(cart);
        return cart;
    }

    public Guid GenerateCart()
    {
        var cart = new Cart();
        _cartRepository.CreateCart(cart);
        return cart.Id;
    }
}