using System.Net.Http.Json;
using Api.Spec.Setup;
using FluentAssertions;
using Infrastructure.Read;

namespace Api.Spec;

public class WhenCreatingACart : WebApiFixture
{
    public WhenCreatingACart(IntegrationTestingFactory<Program> factory)
        : base(factory, "cart")
    { }

    [Fact]
    public async void ThenEmptyCartExists()
    {
        var result = await HttpClient.PostAsJsonAsync("", new object());
        var id = Guid.Parse(result.Headers.Location.Segments[^1]);

        var cartReadService = Resolve<ICartReadService>();
        var generatedCart = cartReadService.Find(id);

        generatedCart.Id.Should().NotBeEmpty();
    }
}