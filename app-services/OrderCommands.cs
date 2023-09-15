namespace App.Services
{

    public record SubmitOrderCommand(
        List<LineItem> LineItems
    );

    public record LineItem(
        Guid ProductId,
        ushort Quantity,
        decimal Price
    );
}