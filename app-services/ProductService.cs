using Domain;

namespace App.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void Register(RegisterProductCommand args)
    {
        var (name, description, sku) = args;
        var product = new Product(name, description, sku);
        _productRepository.Create(product);
    }
}