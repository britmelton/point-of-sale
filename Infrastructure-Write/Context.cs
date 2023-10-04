using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Write;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    { }

    public DbSet<Cart> Cart { get; set; }
    public DbSet<CartLineItem> CartLineItem { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<LineItem> LineItem { get; set; }
    public DbSet<Product> Product { get; set; }
}