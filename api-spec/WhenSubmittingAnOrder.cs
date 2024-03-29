using System.Net.Http.Json;
using Api.DataContracts;
using Api.Spec.Setup;
using FluentAssertions;
using Infrastructure.Read;
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
            var product = new Domain.Product("name", 4.99m, "abc123", 35);
            var lineItem = new LineItem(product.Id,3, 5.99m);

            var dto = new SubmitOrder(new(){lineItem});
            var result = await HttpClient.PostAsJsonAsync("", dto);

            var readService = Resolve<IOrderReadService>();
            var id = Guid.Parse(result.Headers.Location.Segments[^1]);

            var order = readService.Find(id);

            order.Should().NotBeNull();
            order.Total.Should().Be(17.97m);
            order.OrderNumber.Should().NotBeNullOrEmpty();
            order.LineItems.Count.Should().Be(1);
            order.IsComplete.Should().BeTrue();
        }
    }
}