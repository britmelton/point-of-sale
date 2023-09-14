using Api.DataContracts;
using App.Services;
using Infrastructure.Read;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderReadService _orderReadService;
        private readonly IOrderService _orderService;

        public OrderController(IOrderReadService orderReadService, IOrderService orderService)
        {
            _orderReadService = orderReadService;
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult SubmitOrder([FromBody] SubmitOrder dto)
        {
            var (lineItems, subtotal, total) = dto;
            var command = new SubmitOrderCommand(lineItems.Select(li => (App.Services.LineItem)li).ToList(), subtotal, total);

            var orderId = _orderService.SubmitOrder(command);
            return CreatedAtRoute(nameof(Find), new { id = orderId }, null);
        }

        [HttpGet("{id}", Name = "Find")]
        public IActionResult Find(Guid id)
        {
            var order = _orderReadService.Find(id);

            return Ok(order);
        }
    }
}
