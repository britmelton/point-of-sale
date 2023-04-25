using domain;
using FluentAssertions;

namespace domain_spec
{
    public class WhenStartingANewOrder
    {
        private readonly Order _order;
        private readonly string _orderNumber = "ORD-123456-XYZ";

        public WhenStartingANewOrder()
        {
            _order = new Order(_orderNumber);
        }

        [Fact]
        public void ThenOrderIdIsSet()
        {
            _order.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void ThenOrderNumberIsSet()
        {
            _order.OrderNumber.Should().Be(_orderNumber);
        }
    }
}
