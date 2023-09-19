using Domain;

namespace App.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _prodcutRepository;

    public ProductService(IProductRepository productRepository)
    {
        _prodcutRepository = productRepository;
    }

    public void Register(RegisterProductCommand args)
    {
        var (name, description, sku) = args;
        var product = new Product(name, description, sku);
        _prodcutRepository.Create(product);
    }
}