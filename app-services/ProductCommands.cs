namespace App.Services;

public record RegisterProductCommand(
    string Name,
    decimal Price,
    string Sku
    );