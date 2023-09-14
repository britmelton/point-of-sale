using FluentAssertions;
using FluentAssertions.Execution;

namespace Domain.Spec
{
    public class WhenSubmittingAnOrder
    {
        private readonly Order _order;
        private readonly Product _product = new("product1", 3.99m, "abc345");
        private readonly Product _product2 = new("product2", 4.99m, "abc789");
        private readonly LineItem _lineItem;
        private readonly LineItem _lineItem2;

        public WhenSubmittingAnOrder()
        {
            _order = new();
            _lineItem = new(_order.Id, _product, 7.89m);
            _lineItem2 = new(_order.Id, _product2, 4.89m);
            _order.Add(_lineItem);
            _order.Add(_lineItem2);
        }

        [Fact]
        public void ThenIsCompletedIsTrue()
        {
            _order.Submit();

            _order.IsComplete.Should().BeTrue();
        }

        [Fact]
        public void ThenTotalIsSet()
        {
            _order.Submit();

            var expected = _lineItem.Price + _lineItem2.Price;

            using var scope = new AssertionScope();
            _order.Total.Should().NotBe(0);
            _order.Total.Should().Be(expected);
        }
    }
}