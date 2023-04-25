using domain;
using FluentAssertions;

namespace domain_spec
{
    public class WhenRegisteringAProduct
    {
        private readonly Product _product;
        private readonly string _name = "name";
        private readonly decimal _price = 2.99m;
        private readonly string _sku = "abc123";

        public WhenRegisteringAProduct()
        {
            _product = new Product(_name, _price, _sku);
        }

        [Fact]
        public void ThenIdIsSet()
        {
            _product.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void ThenNameIsSet()
        {
            _product.Name.Should().Be(_name);
        }

        [Fact]
        public void ThenPriceIsSet()
        {
            _product.Price.Should().Be(_price);
        }

        [Fact]
        public void ThenSkuIsSet()
        {
            _product.Sku.Should().Be(_sku);
        }
    }
}
