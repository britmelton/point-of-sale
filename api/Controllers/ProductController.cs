using Api.DataContracts;
using App.Services;
using Infrastructure.Read;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IProductReadService _productReadService;
    public ProductController(IProductService productService, IProductReadService productReadService)
    {
        _productService = productService;
        _productReadService = productReadService;
    }

    [HttpGet]
    public IActionResult Fetch()
    {
        var products = _productReadService.Fetch();
        return Ok(products);
    }

    [HttpGet("{sku}", Name = "FindProduct")]
    public IActionResult Find(string sku)
    {
        var product = _productReadService.Find(sku);
        return Ok(product);
    }

    [HttpPost]
    public IActionResult RegisterProduct([FromBody] RegisterProduct dto)
    {
        var (name, price, sku) = dto;
        var command = new RegisterProductCommand(name, price, sku);

        _productService.Register(command);
        return CreatedAtRoute("FindProduct", new { sku }, null);
    }
}

