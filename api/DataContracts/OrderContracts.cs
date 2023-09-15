namespace Api.DataContracts
{
    public record OrderDetails(
        bool IsComplete,
        List<LineItem> LineItems,
        string OrderNumber,
        decimal Subtotal,
        decimal Total
    );

    public record SubmitOrder(
        List<LineItem> LineItems
    );
}
