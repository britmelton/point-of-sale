namespace Domain;

public interface IProductRepository
{
    void Create(Product product);
    Product Find(Guid id);
    void Update(Product product);
}