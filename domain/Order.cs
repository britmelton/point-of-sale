using System.Security.Cryptography;

namespace Domain;
public partial class Order : Entity
{
    public Order(Guid id = default) : base(id)
    {
        OrderNumber = GenerateOrderNumber();
        LineItems = new();
    }

    public Order(List<LineItem> lineItems, string orderNumber, decimal subtotal, decimal total, Guid id = default) : base(id)
    {
        LineItems = lineItems;
        OrderNumber = orderNumber;
        Subtotal = subtotal;
        Total = total;
        OrderNumber = GenerateOrderNumber();
    }

    public bool IsComplete { get; set; }
    public string OrderNumber { get; }
    public List<LineItem> LineItems { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Total { get; set; }

    public void Add(LineItem lineItem)
    {
        LineItems.Add(lineItem);
        lineItem.Quantity++;

        CalculateSubtotal();
    }

    public void AddLineItem(Guid productId, ushort quantity, decimal price)
    {
        var lineItem = new LineItem(Id, productId, price, quantity);

        LineItems.Add(lineItem);
        CalculateSubtotal();
    }

    public void CalculateSubtotal()
    {
        foreach (var lineItem in LineItems)
        {
            lineItem.CalculateTotal();
        }
        var subtotal = LineItems.Sum(li => li.Total);

        Subtotal = subtotal;
    }

    private static string GenerateOrderNumber()
    {
        var random = new byte[4];
        var r = string.Empty;

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(random);
            r = Convert.ToBase64String(random);
        }

        return $"ORD-{r}";
    }

    public void RemoveLineItem(Guid id, ushort quantity)
    {
        var lineItem = LineItems.First(li => li.Id == id);

        lineItem.Quantity -= quantity;
        if(lineItem.Quantity == 0)
            LineItems.Remove(lineItem);

        lineItem.CalculateTotal();
        CalculateSubtotal();
    }

    public void Submit()
    {
        Total = Subtotal;
        IsComplete = true;
    }
}