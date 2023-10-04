using Infrastructure.Read.Dtos;

namespace Infrastructure.Read;

public class Order //reps order Table
{
    #region Public Interface

    public Guid Id { get; init; } //allows you to do the object initialization 
    public bool IsComplete { get; init; }
    public string OrderNumber { get; init; }
    public decimal Subtotal { get; init; }
    public decimal Total { get; init; }

    #endregion
}

public class OrderDto
{
    private readonly List<LineItemDto> _lineItems = new();

    #region Creation

    public OrderDto(Guid id, bool isComplete, string orderNumber, decimal subtotal, decimal total)
    {
        Id = id;
        IsComplete = isComplete;
        OrderNumber = orderNumber;
        Subtotal = subtotal;
        Total = total;
    }

    public OrderDto(Order order) : this(order.Id, order.IsComplete, order.OrderNumber, order.Subtotal, order.Total)
    {
    }

    #endregion

    #region Public Interface

    public Guid Id { get; }
    public bool IsComplete { get; }
    public IReadOnlyList<LineItemDto> LineItems => _lineItems.AsReadOnly();
    public string OrderNumber { get; }
    public decimal Subtotal { get; }
    public decimal Total { get; }

    public void Add(LineItemDto lineItem)
    {
        _lineItems.Add(lineItem);
    }

    #endregion

    #region Static Interface

    public static implicit operator OrderDto(Order order) => new(order);

    #endregion
}
