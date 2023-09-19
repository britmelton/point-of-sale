using Domain;
using System.Linq.Expressions;

namespace Infrastructure.Write;

public class ProductRepository : IProductRepository
{
    private readonly Context _context;

    public ProductRepository(Context context)
    {
        _context = context;
    }

    public void Create(Domain.Product product)
    {
        var dbProduct = new Product(product);

        _context.Product.Add(dbProduct);
        _context.SaveChanges();
    }

    private Domain.Product Find(Expression<Func<Product, bool>> predicate) => _context.Product.First(predicate);
    public Domain.Product Find(Guid id) => Find(x => x.Id == id);
    private Product FindInf(Expression<Func<Product, bool>> predicate) => _context.Product.First(predicate);
    private Product FindInf(Guid id) => FindInf(x => x.Id == id);

    public void Update(Domain.Product product)
    {
        var storedProduct = FindInf(product.Id);
        storedProduct.Update(product);

        _context.SaveChanges();
    }
}