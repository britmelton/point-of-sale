using FluentAssertions;
using FluentAssertions.Execution;
using static Domain.Spec.Kernel.ObjectProvider;

namespace Domain.Spec;

public class WhenRemovingLineItemFromOrder
{
    private Order _order;

    public WhenRemovingLineItemFromOrder()
    {
        _order = SubmitOrder(LineItems2);
    }

    [Fact]
    public void ThenLineItemDoesNotExistInOrder()
    {
        var lineItem = _order.LineItems[0];
        _order.RemoveLineItem(lineItem.Id, lineItem.Quantity);

        _order.LineItems.Should().NotContain(lineItem);
    }

    [Fact]
    public void ThenLineItemQuantityIsUpdated()
    {
        var lineItem = _order.LineItems[0];
        var expectedQuantity = lineItem.Quantity - 4;

        _order.RemoveLineItem(lineItem.Id, 4);

        _order.LineItems[0].Quantity.Should().Be((ushort)expectedQuantity);
    }

    [Fact]
    public void ThenLineItemSubtotalIsUpdated()
    {
        var lineItem = _order.LineItems[0];
        _order.RemoveLineItem(lineItem.Id, 4);

        var expectedSubtotal = lineItem.Price * lineItem.Quantity;
        _order.LineItems[0].Subtotal.Should().Be(expectedSubtotal);
    }

    [Fact]
    public void ThenSubtotalIsUpdated()
    {
        var lineItem = _order.LineItems[0];
        var lineItem2 = _order.LineItems[1];
        var lineItem3 = _order.LineItems[2];

        _order.RemoveLineItem(lineItem.Id, lineItem.Quantity);
        _order.RemoveLineItem(lineItem2.Id, lineItem2.Quantity);

        var expectedSubtotal = lineItem3.Price * lineItem3.Quantity;
        _order.Subtotal.Should().Be(expectedSubtotal);
    }

    [Fact]
    public void WhereMultipleLineItemsAreRemoved_ThenLineItemsDoNotExistInOrder()
    {
        var lineItem = _order.LineItems[0];
        var lineItem2 = _order.LineItems[1];

        _order.RemoveLineItem(lineItem.Id, lineItem.Quantity);
        _order.RemoveLineItem(lineItem2.Id, lineItem2.Quantity);

        using var scope = new AssertionScope();
        _order.LineItems.Should().NotContain(lineItem);
        _order.LineItems.Should().NotContain(lineItem2);
    }
}