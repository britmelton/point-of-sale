using domain;
using FluentAssertions;

namespace domain_spec
{
    public class WhenAddingProductToOrder
    {
        private readonly Order _order;
        private readonly Product _product = new("product1", 3.99m, "abc345");
        private readonly Product _product2 = new("product2", 4.99m, "abc789");

        public WhenAddingProductToOrder()
        {
            _order = new();
        }

        [Fact]
        public void ThenProductExistsInOrder()
        {
            _order.Products.Add(_product);

            _order.Products.Should().Contain(_product);
        }

        [Fact]
        public void WithMultipleProducts_ThenAllProductsExistInOrder()
        {
            _order.Products.Add(_product);
            _order.Products.Add(_product2);

            _order.Products.Should().Contain(_product);
            _order.Products.Should().Contain(_product2);
        }
    }
}
