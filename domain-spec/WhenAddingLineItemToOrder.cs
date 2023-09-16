using Domain.Spec.Kernel;
using FluentAssertions;

namespace Domain.Spec;

public class WhenAddingLineItemToOrder
{
    private static readonly Product _product = new("product1", 3.99m, "abc345");
    private static readonly Product _product2 = new("product2", 4.99m, "abc789");
    private static readonly Kernel.LineItem _lineItem = new(_product.Id, 6, 4.99m);
    private static readonly Kernel.LineItem _lineItem2 = new(_product2.Id, 7, 8.99m);

    public static IEnumerable<object[]> LineItems()
    {
        yield return new object[] { new List<Kernel.LineItem>() { _lineItem, _lineItem2 } };
    }

    public static Order CreateOrder(List<Kernel.LineItem> lineItems)
    {
        var order = new UnitTestOrderBuilder()
            .Load(lineItems)
            .Build()
            .GetOrder();
        return order;
    }
    
    [Theory]
    [MemberData(nameof(LineItems))]
    public void ThenLineItemsExistsInOrder(List<Kernel.LineItem> lineItems)
    {
        var order = CreateOrder(lineItems);

        order.LineItems[0].Should().NotBeNull();
        order.LineItems[1].Should().NotBeNull();
    }

    [Theory]
    [MemberData(nameof(LineItems))]
    public void ThenLineItemsQuantityIsUpdated(List<Kernel.LineItem> lineItems)
    {

        var order = CreateOrder(lineItems);
        order.LineItems[0].Quantity.Should().Be(6);
        order.LineItems[1].Quantity.Should().Be(7);
    }

    [Theory]
    [MemberData(nameof(LineItems))]
    public void ThenSubtotalIsUpdated(List<Kernel.LineItem> lineItems)
    {
        var order = CreateOrder(lineItems);

        var expectedSubtotal = 92.87m;

        order.Subtotal.Should().Be(expectedSubtotal);
    }
}