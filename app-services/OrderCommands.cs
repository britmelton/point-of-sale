namespace App.Services
{

    public record SubmitOrderCommand(
        List<LineItem> LineItems,
        decimal Subtotal,
        decimal Total
    );

    public record LineItem(
        Guid ProductId,
        ushort Quantity,
        decimal Price
    );
}