using Domain.Spec.Kernel;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Domain.Spec;

public class WhenRemovingLineItemFromOrder
{
    private static readonly Product _product = new("product1", 3.99m, "abc345");
    private static readonly Product _product2 = new("product2", 4.99m, "abc789");
    private static readonly Product _product3 = new("product3", 6.99m, "abc749");
    private static readonly Kernel.LineItem _lineItem = new(_product.Id, 6, 4.99m);
    private static readonly Kernel.LineItem _lineItem2 = new(_product2.Id, 7, 8.99m);
    private static readonly Kernel.LineItem _lineItem3 = new(_product3.Id, 8, 5.89m);

    public static IEnumerable<object[]> LineItems()
    {
        yield return new object[] { new List<Kernel.LineItem>() { _lineItem, _lineItem2, _lineItem3 } };
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


    [Theory]
    [MemberData(nameof(LineItems))]
    public void ThenLineItemDoesNotExistInOrder(List<Kernel.LineItem> lineItems)
    {
        var order = SubmitOrder(lineItems);
        var lineItem = order.LineItems[0];

        order.RemoveProduct(lineItem.Id);

        order.LineItems.Should().NotContain(lineItem);
    }

    [Theory]
    [MemberData(nameof(LineItems))]
    public void WhereMultipleLineItemsAreRemoved_ThenLineItemsDoNotExistInOrder(List<Kernel.LineItem> lineItems)
    {
        var order = SubmitOrder(lineItems);
        var lineItem = order.LineItems[0];
        var lineItem2 = order.LineItems[1];

        order.RemoveProduct(lineItem.Id);
        order.RemoveProduct(lineItem2.Id);

        using var scope = new AssertionScope();
        order.LineItems.Should().NotContain(lineItem);
        order.LineItems.Should().NotContain(lineItem2);
    }

    [Theory]
    [MemberData(nameof(LineItems))]
    public void ThenSubtotalIsUpdated(List<Kernel.LineItem> lineItems)
    {
        var order = SubmitOrder(lineItems);
        var lineItem = order.LineItems[0];
        var lineItem2 = order.LineItems[1];

        order.RemoveProduct(lineItem.Id);
        order.RemoveProduct(lineItem2.Id);

        var expectedSubtotal = _lineItem3.Price;

        order.Subtotal.Should().Be(expectedSubtotal);
    }
}