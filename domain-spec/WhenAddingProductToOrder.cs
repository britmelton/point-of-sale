using domain;
using FluentAssertions;

namespace domain_spec
{
    public class WhenAddingProductToOrder
    {
        [Fact]
        public void ThenProductExistsInOrder()
        {
            var order = new Order();
            var product = new Product("product1", 3.99m, "abc345");
            order.Products.Add(product);

            order.Products.Should().Contain(product);
        }

        [Fact]
        public void WithMultipleProduct_ThenAllProductsExistInOrder()
        {
            var order = new Order();
            var product = new Product("product1", 3.99m, "abc345");
            var product2 = new Product("product2", 4.99m, "abc789");

            order.Products.Add(product);
            order.Products.Add(product2);

            order.Products.Should().Contain(product);
            order.Products.Should().Contain(product2);
        }
    }
}
