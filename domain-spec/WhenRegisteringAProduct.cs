using domain;
using FluentAssertions;

namespace domain_spec
{
    public class WhenRegisteringAProduct
    {
        [Fact]
        public void ThenNameIsSet()
        {
            var product = new Product("name", 2.99m, "abc123");

            product.Name.Should().Be("name");
        }

        [Fact]
        public void ThenSkuIsSet()
        {
            var product = new Product("name",2.99m, "abc123");

            product.Sku.Should().Be("abc123");
        }

        [Fact]
        public void ThenPriceIsSet()
        {
            var product = new Product("name",2.99m, "abc123");

            product.Price.Should().Be(2.99m);
        }
    }
}
