using Domain.Spec.Kernel;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Domain.Spec;

public class WhenSubmittingAnOrder
{
    private static readonly Product _product = new("product1", 3.99m, "abc345");
    private static readonly Product _product2 = new("product2", 4.99m, "abc789");
    private static readonly Kernel.LineItem _lineItem = new(_product.Id, 6, 4.99m);
    private static readonly Kernel.LineItem _lineItem2 = new(_product2.Id, 7, 8.99m);

    public static IEnumerable<object[]> LineItems()
    {
        yield return new object[] { new List<Kernel.LineItem>() { _lineItem, _lineItem2 } };
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
    public void ThenLineItemsExistInOrder(List<Kernel.LineItem> lineItems)
    {
        var order = SubmitOrder(lineItems);

        order.LineItems.Should().HaveCount(2);
    }

    [Theory]
    [MemberData(nameof(LineItems))]
    public void ThenIsCompletedIsTrue(List<Kernel.LineItem> lineItems)
    {
        var order = SubmitOrder(lineItems);

        order.IsComplete.Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(LineItems))]
    public void ThenTotalIsSet(List<Kernel.LineItem> lineItems)
    {
        var order = SubmitOrder(lineItems);

        var expected = _lineItem.Price + _lineItem2.Price;

        using var scope = new AssertionScope();
        order.Total.Should().NotBe(0);
        order.Total.Should().Be(expected);
    }
}