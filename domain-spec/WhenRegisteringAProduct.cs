using domain;
using FluentAssertions;

namespace domain_spec
{
    public class WhenRegisteringAProduct
    {
        [Fact]
        public void ThenNameIsSet()
        {
            var product = new Product("name");

            product.Name.Should().Be("name");
        }
    }
}
