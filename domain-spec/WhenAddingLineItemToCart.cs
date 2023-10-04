using FluentAssertions;

namespace Domain.Spec;

public class WhenAddingLineItemToCart
{
    [Fact]
    public void ThenLineItemExistsInCart()
    {
        var product = new Product("name", 6.76m, "abc345", 45);
        var price = 5.67m;
        ushort quantity = 3;

        var cart = new Cart();
        cart.AddLineItem(product.Id, price, quantity);

        cart.LineItems[0].ProductId.Should().Be(product.Id);
        cart.LineItems[0].Price.Should().Be(price);
        cart.LineItems[0].Quantity.Should().Be(quantity);
    }
}