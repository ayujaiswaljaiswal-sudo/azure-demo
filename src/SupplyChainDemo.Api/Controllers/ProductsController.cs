using Microsoft.AspNetCore.Mvc;
using SupplyChainDemo.Api.Models;
using SupplyChainDemo.Api.Services;

namespace SupplyChainDemo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;
    public ProductsController(IProductService service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var p = _service.Get(id);
        return p is null ? NotFound() : Ok(p);
    }

    [HttpPost]
    public IActionResult Create(Product p)
    {
        var created = _service.Add(p);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, Product p)
    {
        if (!_service.Update(id, p)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_service.Delete(id)) return NotFound();
        return NoContent();
    }

    [HttpPost("{id:guid}/order")]
    public IActionResult Order(Guid id, [FromQuery] int qty = 1)
    {
        var order = _service.CreateOrder(id, qty);
        return order is null ? BadRequest(new { message = "Insufficient stock or product not found" }) : Ok(order);
    }
}
