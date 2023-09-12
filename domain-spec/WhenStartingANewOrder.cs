using FluentAssertions;

namespace Domain.Spec
{
    public class WhenStartingANewOrder
    {
        private readonly Order _order;

        public WhenStartingANewOrder()
        {
            _order = new();
        }

        [Fact]
        public void ThenOrderIdIsSet()
        {
            _order.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void ThenOrderNumberIsSet()
        {
            _order.OrderNumber.Should().NotBeEmpty();
        }
    }
}