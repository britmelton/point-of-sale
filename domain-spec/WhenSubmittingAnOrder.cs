using FluentAssertions;
using FluentAssertions.Execution;
using static Domain.Spec.Kernel.ObjectProvider;

namespace Domain.Spec;

public class WhenSubmittingAnOrder
{
    private Order _order;

    public WhenSubmittingAnOrder()
    {
        _order = SubmitOrder(LineItems);
    }

    [Fact]
    public void ThenIdIsSet()
    {
        _order.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void ThenOrderNumberIsSet()
    {
        _order.OrderNumber.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void ThenLineItemsExistInOrder()
    {
        _order.LineItems.Should().HaveCount(2);
    }

    [Fact]
    public void ThenIsCompletedIsTrue()
    {
        _order.IsComplete.Should().BeTrue();
    }

    [Fact]
    public void ThenTotalIsSet()
    {
        var lineItem = _order.LineItems[0];
        var lineItem2 = _order.LineItems[1];

        var expectedTotal = (lineItem.Price * lineItem.Quantity) + (lineItem2.Price * lineItem2.Quantity);

        using var scope = new AssertionScope();
        _order.Total.Should().NotBe(0);
        _order.Total.Should().Be(expectedTotal);
    }
}