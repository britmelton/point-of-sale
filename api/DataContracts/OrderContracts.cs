namespace Api.DataContracts
{
    public record OrderDetails(
        List<LineItem> LineItems,
        string OrderNumber,
        decimal Subtotal,
        decimal Total
    );

    public record SubmitOrder(
        List<LineItem> LineItems,
        decimal Subtotal,
        decimal Total
    );
}
