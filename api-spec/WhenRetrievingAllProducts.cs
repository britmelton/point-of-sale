using Api.DataContracts;
using Api.Spec.Setup;
using System.Net.Http.Json;
using FluentAssertions;

namespace Api.Spec;

public class WhenRetrievingAllProducts : WebApiFixture
{
    public WhenRetrievingAllProducts(IntegrationTestingFactory<Program> factory)
        : base(factory, "product") { }

    [Fact]
    public async void ThenAllProductsAreReturned()
    {
        var products = await HttpClient.GetFromJsonAsync<List<ProductDetails>>("");
        products.Should().NotBeNull();
    }
}