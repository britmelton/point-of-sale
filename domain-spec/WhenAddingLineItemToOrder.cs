using FluentAssertions;
using FluentAssertions.Execution;

namespace Domain.Spec
{
    public class WhenAddingLineItemToOrder
    {
        private readonly Order _order;
        private readonly Product _product = new("product1", 3.99m, "abc345");
        private readonly Product _product2 = new("product2", 4.99m, "abc789");

        public WhenAddingLineItemToOrder()
        {
            _order = new();
        }

        [Fact]
        public void ThenLineItemExistsInOrder()
        {
            var lineItem = new LineItem(_order.Id, _product, 4.78m);

            _order.Add(lineItem);

            _order.LineItems.Should().Contain(lineItem);
        }

        [Fact]
        public void ThenLineItemQuantityIsUpdated()
        {
            var lineItem = new LineItem(_order.Id, _product, 2.75m);

            _order.Add(lineItem);
            _order.Add(lineItem);

            _order.LineItems[0].Quantity.Should().Be(2);
        }

        [Fact]
        public void ThenEachLineItemQuantityIsUpdated()
        {
            var lineItem = new LineItem(_order.Id, _product, 7.89m);
            var lineItem2 = new LineItem(_order.Id, _product2, 7.89m);

            _order.Add(lineItem);
            _order.Add(lineItem);
            _order.Add(lineItem2);
            _order.Add(lineItem2);
            _order.Add(lineItem2);

            _order.LineItems[0].Quantity.Should().Be(2);
            _order.LineItems[2].Quantity.Should().Be(3);
        }

        [Fact]
        public void WithMultipleLineItems_ThenOrderContainsAll()
        {
            var lineItem = new LineItem(_order.Id, _product, 4.67m);
            var lineItem2 = new LineItem(_order.Id, _product2, 7.89m);
            _order.Add(lineItem);
            _order.Add(lineItem2);

            using var scope = new AssertionScope();
            _order.LineItems.Should().Contain(lineItem);
            _order.LineItems.Should().Contain(lineItem2);
        }

        [Fact]
        public void WithOnlyOneLineItem_ThenSubtotalIsUpdated()
        {
            var lineItem = new LineItem(_order.Id, _product, 2.99m);
            _order.Add(lineItem);
            _order.CalculateSubtotal();

            var expectedSubtotal = 2.99m;

            _order.Subtotal.Should().Be(expectedSubtotal);
        }

        [Fact]
        public void WithMultipleLineItems_ThenSubtotalIsUpdated()
        {
            var lineItem = new LineItem(_order.Id, _product, 7.89m);
            var lineItem2 = new LineItem(_order.Id, _product2, 5.99m);
            _order.Add(lineItem);
            _order.Add(lineItem2);

            _order.CalculateSubtotal();

            var expectedSubtotal = 7.89m + 5.99m;

            _order.Subtotal.Should().Be(expectedSubtotal);
        }
    }
}