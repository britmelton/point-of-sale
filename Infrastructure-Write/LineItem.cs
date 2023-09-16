using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Write
{
    public class LineItem : Entity
    {
        public LineItem() { }
        public LineItem(Domain.LineItem lineItem) : base(lineItem.Id)
        {
            OrderId = lineItem.OrderId;
            Price = lineItem.Price;
            ProductId = lineItem.ProductId;
            Quantity = lineItem.Quantity;
            Subtotal = lineItem.Subtotal;
        }

        public Guid OrderId { get; set; }
        [Precision(6, 2)]
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public ushort Quantity { get; set; }
        [Precision(6, 2)]
        public decimal Subtotal { get; set; }


        public static implicit operator Domain.LineItem(LineItem source) => new(source.OrderId, source.ProductId, source.Price, source.Quantity, source.Id);

        public static implicit operator LineItem(Domain.LineItem source) => new(source);

        public LineItem Update(Domain.LineItem lineItem)
        {
            OrderId = lineItem.OrderId;
            ProductId = lineItem.ProductId;
            Price = lineItem.Price;
            Quantity = lineItem.Quantity;
            Subtotal = lineItem.Subtotal;

            return this;
        }
    }
}
