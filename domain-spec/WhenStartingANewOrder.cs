using domain;
using FluentAssertions;

namespace domain_spec
{
    public class WhenStartingANewOrder
    {
        [Fact]
        public void ThenOrderNumberIsRegistered()
        {
            var order = new Order();

            order.Id.Should().NotBeEmpty();
        }
    }
}
