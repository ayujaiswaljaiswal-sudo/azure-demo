using Microsoft.AspNetCore.Mvc;
using SupplyChainDemo.Api.Services;

namespace SupplyChainDemo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IProductService _service;
    public OrdersController(IProductService service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetOrders());
}
