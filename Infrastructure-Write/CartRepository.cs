using Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Write;

public class CartRepository : ICartRepository
{
    private readonly Context _context;

    public CartRepository(Context context)
    {
        _context = context;
    }

    public void CreateCart(Domain.Cart cart)
    {
        var dbCart = new Cart(cart);

        _context.Cart.Add(dbCart);
        _context.SaveChanges();
    }

    private Domain.Cart Find(Expression<Func<Cart, bool>> predicate) => _context.Cart.First(predicate);
    public Domain.Cart Find(Guid id) => Find(x => x.Id == id);
    private Cart FindInf(Expression<Func<Cart, bool>> predicate) => _context.Cart.First(predicate);
    private Cart FindInf(Guid id) => FindInf(x => x.Id == id);

    public void Update(Domain.Cart cart)
    {
        var dbCart = _context.Cart
            .Include(x => x.LineItems)
            .First(x => x.Id == cart.Id);
        dbCart.Update(cart);

        _context.Cart.Update(dbCart);

        _context.SaveChanges();
    }
}