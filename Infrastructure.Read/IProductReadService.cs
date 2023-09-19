namespace Infrastructure.Read;
public interface IProductReadService
    {
        Product Find(string sku);
        IEnumerable<Product> Fetch();
    }