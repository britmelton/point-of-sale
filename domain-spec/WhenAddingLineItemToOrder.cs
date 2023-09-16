using FluentAssertions;
using FluentAssertions.Execution;
using static Domain.Spec.Kernel.ObjectProvider;

namespace Domain.Spec;

public class WhenAddingLineItemToOrder
{
    private Order _order;

    public WhenAddingLineItemToOrder()
    {
        _order = CreateOrder(LineItems);
    }

    [Fact]
    public void ThenLineItemsExistsInOrder()
    {
        using var scope = new AssertionScope();
        _order.LineItems[0].Should().BeEquivalentTo(_LineItem);
        _order.LineItems[1].Should().BeEquivalentTo(_LineItem2);
    }

    [Fact]
    public void ThenLineItemsQuantityIsUpdated()
    {
        using var scope = new AssertionScope();
        _order.LineItems[0].Quantity.Should().Be(_LineItem.Quantity);
        _order.LineItems[1].Quantity.Should().Be(_LineItem2.Quantity);
    }

    [Fact]
    public void ThenSubtotalIsUpdated()
    {
        var lineItem = _order.LineItems[0];
        var lineItem2 = _order.LineItems[1];

        var expectedSubtotal = (lineItem.Price * lineItem.Quantity) + (lineItem2.Price * lineItem2.Quantity);

        _order.Subtotal.Should().Be(expectedSubtotal);
    }
}