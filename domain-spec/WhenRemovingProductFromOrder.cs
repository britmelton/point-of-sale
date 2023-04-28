using domain;
using FluentAssertions;

namespace domain_spec
{
    public class WhenRemovingProductFromOrder
    {
        private readonly Order _order;
        private readonly Product _product = new("product1", 3.99m, "abc345");
        private readonly Product _product2 = new("product2", 4.99m, "abc789");

        public WhenRemovingProductFromOrder()
        {
            _order = new();
        }

        [Fact]
        public void ThenProductDoesNotExistInOrder()
        {
            _order.Add(_product);
            _order.Add(_product2);

            _order.RemoveProduct(_product.Sku);

            _order.Products.Should().NotContain(_product);
        }

        [Fact]
        public void WhereMultipleProductsAreRemoved_ThenProductsDoNotExistInOrder()
        {
            _order.Add(_product);
            _order.Add(_product2);

            _order.RemoveProduct(_product.Sku);
            _order.RemoveProduct(_product2.Sku);

            _order.Products.Should().NotContain(_product);
            _order.Products.Should().NotContain(_product2);
        }
    }
}
