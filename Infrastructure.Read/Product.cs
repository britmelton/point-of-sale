namespace Infrastructure.Read;

public class Product
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public ushort QuantityOnHand { get; init; }
    public string Sku { get; init; }
}