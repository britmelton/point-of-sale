namespace Api.DataContracts;

public record RegisterProduct(
    string Name,
    decimal Price,
    string Sku
    );

public record ProductDetails(
    string Name,
    decimal Price,
    string Sku
    );

