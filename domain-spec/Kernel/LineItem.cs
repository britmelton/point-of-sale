namespace Domain.Spec.Kernel;

public record LineItem(
    Guid ProductId,
    ushort Quantity,
    decimal Price
);