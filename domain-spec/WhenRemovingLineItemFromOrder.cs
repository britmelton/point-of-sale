using FluentAssertions;
using FluentAssertions.Execution;

namespace Domain.Spec
{
    public class WhenRemovingLineItemFromOrder
    {
        private readonly Order _order;
        private readonly Product _product = new("product1", 3.99m, "abc345");
        private readonly Product _product2 = new("product2", 4.99m, "abc789");
        private readonly Product _product3 = new("product3", 6.99m, "abc749");
        private readonly LineItem _lineItem;
        private readonly LineItem _lineItem2;
        private readonly LineItem _lineItem3;

        public WhenRemovingLineItemFromOrder()
        {
            _order = new();
            _lineItem = new(_order.Id, _product, 3.99m);
            _lineItem2 = new(_order.Id, _product2, 7.89m);
            _lineItem3 = new(_order.Id, _product3, 4.99m);

            _order.Add(_lineItem);
            _order.Add(_lineItem2);
            _order.Add(_lineItem3);
        }

        [Fact]
        public void ThenLineItemDoesNotExistInOrder()
        {
            _order.RemoveProduct(_lineItem.Id);

            _order.LineItems.Should().NotContain(_lineItem);
        }

        [Fact]
        public void WhereMultipleLineItemsAreRemoved_ThenLineItemsDoNotExistInOrder()
        {
            _order.RemoveProduct(_lineItem.Id);
            _order.RemoveProduct(_lineItem2.Id);

            using var scope = new AssertionScope();
            _order.LineItems.Should().NotContain(_lineItem);
            _order.LineItems.Should().NotContain(_lineItem2);
        }

        [Fact]
        public void ThenSubtotalIsUpdated()
        {
            _order.RemoveProduct(_lineItem.Id);
            _order.RemoveProduct(_lineItem2.Id);

            var expectedSubtotal = _lineItem3.Price;

            _order.Subtotal.Should().Be(expectedSubtotal);
        }
    }
}