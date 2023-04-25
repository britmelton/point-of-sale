using domain;
using FluentAssertions;

namespace domain_spec
{
    public class WhenRegisteringAProduct
    {
        [Fact]
        public void ThenNameIsSet()
        {
            var product = new Product("name", "abc123");

            product.Name.Should().Be("name");
        }

        [Fact]
        public void ThenSkuIsSet()
        {
            var product = new Product("name", "abc123");

            product.Sku.Should().Be("abc123");
        }
    }
}
