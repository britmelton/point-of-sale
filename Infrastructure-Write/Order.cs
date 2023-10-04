using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Write;

public class Order : Entity
{
    public Order() { }

    public Order(Domain.Order order) : base(order.Id)
    {
        IsComplete = order.IsComplete;
        LineItems = order.LineItems.Select(li => (LineItem)li).ToList();
        OrderNumber = order.OrderNumber;
        Subtotal = order.Subtotal;
        Total = order.Total;
    }

    public bool IsComplete { get; set; }
    public List<LineItem> LineItems { get; set; }
    public string OrderNumber { get; set; }
    [Precision(6, 2)]
    public decimal Subtotal { get; set; }
    [Precision(6, 2)]
    public decimal Total { get; set; }

    public static implicit operator Domain.Order(Order source)
    {
        return new(source.LineItems.Select(li => (Domain.LineItem)li).ToList(), source.OrderNumber, source.Subtotal, source.Total, source.Id);
    }

    public static implicit operator Order(Domain.Order source) =>
        new(source);

    public Order Update(Domain.Order order)
    {
        IsComplete = order.IsComplete;
        LineItems = order.LineItems.Select(l => (LineItem)l).ToList();
        Subtotal = order.Subtotal;
        Total = order.Total;

        return this;
    }
}