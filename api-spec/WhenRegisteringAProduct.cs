using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using FluentAssertions;
using Infrastructure.Read;

namespace Api.Spec;

public class WhenRegisteringAProduct : WebApiFixture
{
    public WhenRegisteringAProduct(IntegrationTestingFactory<Program> factory)
        : base(factory, "product")
    { }

    [Fact]
    public async void ThenProductExists()
    {
        var dto = new RegisterProduct("name", 4.99m, "abc123");
        await HttpClient.PostAsJsonAsync("", dto);

        var readService = Resolve<IProductReadService>();
        var product = readService.Find(dto.Sku);

        product.Should().NotBeNull();
        product.Name.Should().Be("name");
    }
}