namespace Domain.Spec.Kernel;

public static class ObjectProvider
{
    public const string _name = "name";
    public const decimal _price = 2.99m;
    public const string _sku = "abc123";
    public static readonly Product _Product = new(_name, _price, _sku);


    public static readonly Product _Product1 = new("product1", 3.99m, "abc345");
    public static readonly Product _Product2 = new("product2", 4.99m, "abc789");
    private static readonly Product _Product3 = new("product3", 6.99m, "abc749");

    public static readonly LineItem _LineItem = new(_Product1.Id, 6, 4.99m);
    public static readonly LineItem _LineItem2 = new(_Product2.Id, 7, 8.99m);
    public static readonly LineItem _LineItem3 = new(_Product3.Id, 8, 5.89m);


    public static List<LineItem> LineItems = new()
    {
        _LineItem,
        _LineItem2
    };

    public static List<LineItem> LineItems2 = new()
    {
        _LineItem,
        _LineItem2,
        _LineItem3
    };

    public static Order CreateOrder(List<LineItem> lineItems)
    {
        var order = new UnitTestOrderBuilder()
            .Load(lineItems)
            .Build()
            .GetOrder();
        return order;
    }

    public static Order SubmitOrder(List<Kernel.LineItem> lineItems)
    {
        var order = new UnitTestOrderBuilder()
            .Load(lineItems)
            .Build()
            .GetOrder();
        order.Submit();
        return order;
    }
}