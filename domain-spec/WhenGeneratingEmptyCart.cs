using FluentAssertions;

namespace Domain.Spec;

public class WhenGeneratingEmptyCart
{
    [Fact]
    public void ThenCartIdIsSet()
    {
        var cart = new Cart();

        cart.Id.Should().NotBeEmpty();
    }
}