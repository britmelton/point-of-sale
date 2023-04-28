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
            _order.Add(_product);

            _order.Products.Should().Contain(_product);
        }

        [Fact]
        public void WithMultipleProducts_ThenAllProductsExistInOrder()
        {
            _order.Add(_product);
            _order.Add(_product2);

            _order.Products.Should().Contain(_product);
            _order.Products.Should().Contain(_product2);
        }

        [Fact]
        public void WithOnlyOneProduct_ThenSubtotalIsUpdated()
        {
            _order.Add(_product);
            _order.CalculateSubtotal();

            var expectedSubtotal = _product.Price;

            _order.Subtotal.Should().Be(expectedSubtotal);
        }

        [Fact]
        public void WithMultipleProducts_ThenSubtotalIsUpdated()
        {
            _order.Add(_product);
            _order.Add(_product2);

            _order.CalculateSubtotal();

            var expectedSubtotal = _product.Price + _product2.Price;

            _order.Subtotal.Should().Be(expectedSubtotal);
        }
    }
}
