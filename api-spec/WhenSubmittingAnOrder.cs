using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using Domain;
using FluentAssertions;
using LineItem = Api.DataContracts.LineItem;

namespace Api.Spec
{
    public class WhenSubmittingAnOrder : WebApiFixture
    {
        public WhenSubmittingAnOrder(IntegrationTestingFactory<Program> factory)
            : base(factory, "order")
        { }

        [Fact]
        public async void ThenOrderExists()
        {
            var product = new Product("name", 4.99m, "abc123", 35);
            var lineItem = new LineItem(product.Id,3, 5.99m);

            var dto = new SubmitOrder(new(){lineItem}, 4.99m, 4.99m);

            var result = await HttpClient.PostAsJsonAsync("", dto);

            var order = await HttpClient.GetFromJsonAsync<OrderDetails>(result.Headers.Location);

            order.Should().NotBeNull();
            order.Total.Should().Be(4.99m);
            order.OrderNumber.Should().NotBeNullOrEmpty();
            order.LineItems.Count.Should().Be(1);
        }
    }
}