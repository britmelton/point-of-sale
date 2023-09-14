namespace Api.DataContracts
{
    public record LineItem(
        Guid ProductId,
        ushort Quantity,
        decimal Price
    )
    {
        public static implicit operator LineItem(App.Services.LineItem source) =>
        new(source.ProductId, source.Quantity, source.Price);

        public static implicit operator App.Services.LineItem(LineItem source) =>
            new(source.ProductId, source.Quantity, source.Price);
    }
}
