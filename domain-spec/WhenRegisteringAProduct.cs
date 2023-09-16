using FluentAssertions;
using FluentAssertions.Execution;

namespace Domain.Spec
{
    public class WhenRegisteringAProduct
    {
        private readonly Product _product;
        private const string _name = "name";
        private const decimal _price = 2.99m;
        private const string _sku = "abc123";

        public WhenRegisteringAProduct()
        {
            _product = new(_name, _price, _sku);
        }

        [Fact]
        public void ThenAllPropertiesAreSet()
        {
            using var scope = new AssertionScope();
            _product.Id.Should().NotBeEmpty();
            _product.Name.Should().Be(_name);
            _product.Price.Should().Be(_price);
            _product.Sku.Should().Be(_sku);
        }
    }
}