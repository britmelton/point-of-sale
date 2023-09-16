using FluentAssertions;
using FluentAssertions.Execution;
using static Domain.Spec.Kernel.ObjectProvider;

namespace Domain.Spec
{
    public class WhenRegisteringAProduct
    {
        [Fact]
        public void ThenAllPropertiesAreSet()
        {
            using var scope = new AssertionScope();
            _Product.Id.Should().NotBeEmpty();
            _Product.Name.Should().Be(_name);
            _Product.Price.Should().Be(_price);
            _Product.Sku.Should().Be(_sku);
        }
    }
}