using Api.DataContracts;
using App.Services;
using Infrastructure.Read;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartReadService _cartReadService;
    private readonly ICartService _cartService;
    public CartController(ICartReadService cartReadService, ICartService cartService)
    {
        _cartReadService = cartReadService;
        _cartService = cartService;
    }

    [HttpPost("{id}")]
    public IActionResult Add([FromBody] AddLineItems addLineItems)
    {
        var cart = _cartService.Add(addLineItems);
        return Ok(cart);
    }

    [HttpGet("{id}", Name = "FindCart")]
    public IActionResult Find(Guid id)
    {
        var cart = _cartReadService.Find(id);
        return Ok(cart);
    }

    [HttpPost]
    public IActionResult GenerateCart()
    {
       var id =  _cartService.GenerateCart();

       return CreatedAtRoute("FindCart", new { id }, null);
    }
}