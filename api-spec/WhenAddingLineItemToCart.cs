using Api.Spec.Setup;
using Infrastructure.Read;
using System.Net.Http.Json;
using Api.DataContracts;
using FluentAssertions;

namespace Api.Spec;

public class WhenAddingLineItemToCart : WebApiFixture
{
    public WhenAddingLineItemToCart(IntegrationTestingFactory<Program> factory)
        : base(factory, "cart")
    { }

    [Fact]
    public async void ThenLineItemExistsInCart()
    {
        var result = await HttpClient.PostAsJsonAsync("", new object());
        var id = Guid.Parse(result.Headers.Location.Segments[^1]);

        var cartReadService = Resolve<ICartReadService>();
        var generatedCart = cartReadService.Find(id);

        var dto = new AddLineItems(generatedCart.Id, new() { new(generatedCart.Id, Guid.NewGuid(), 4, 4.99m) });
        await HttpClient.PostAsJsonAsync($"{id}", dto);

        var updatedCart = cartReadService.Find(id);

        updatedCart.Id.Should().Be(id);
        updatedCart.LineItems.Count.Should().Be(1);
    }
}