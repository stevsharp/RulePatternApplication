using Application.Common;
using Application.Features.Orders.Commands;
using Application.Features.Orders.Queries;

using Microsoft.AspNetCore.Mvc;

namespace RulePatternApplication.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    public OrdersController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand cmd)
    {
        var result = await _mediator.SendAsync(cmd);
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> CancelOrder(Guid id)
    {
        var result = await _mediator.SendAsync(new CancelOrderCommand(id));
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var dto = await _mediator.QueryAsync<GetOrderSummaryQuery, OrderSummaryDto>(
            new GetOrderSummaryQuery(id));
        return dto is null ? NotFound() : Ok(dto);
    }
}

