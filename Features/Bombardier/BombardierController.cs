using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Features.Bombardier.RequestHandling.Requests;
using ShopAPI.Features.Common;
using ShopAPI.Features.RequestHandling.Base;
using ShopAPI.Features.Users.RequestHandling.Requests;

namespace ShopAPI.Features.Bombardier;


[Route("api/v1/[controller]")]
[ApiVersion("1.0")]
public class BombardierController : BaseApiController
{
    private readonly IMediator _mediator;
    public BombardierController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("_internal/bookingHistory/{bookingId:guid}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBookingProduct([FromRoute] Guid bookingId,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetBookingProductRequest(bookingId), cancellationToken);
        return result.AsAspNetCoreResult();
    }

    [HttpGet("_internal/deliverylog/{orderId:guid}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetHistory([FromRoute] Guid orderId,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetHistoryRequest(orderId), cancellationToken);
        return result.AsAspNetCoreResult();
    }

    [HttpGet("delivery/slots")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetSlots(
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetSlotsRequest(), cancellationToken);
        return result.AsAspNetCoreResult();
    }

    [HttpGet("delivery/slots")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetSlots([FromQuery] int number,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetSlotsByNumberRequest(number), cancellationToken);
        return result.AsAspNetCoreResult();
    }

    [HttpGet("items")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetItems([FromQuery] Guid orderId,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetItemsRequest(orderId), cancellationToken);
        return result.AsAspNetCoreResult();
    }

    [HttpPost("orders")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> MakeOrder(
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new MakeOrderRequest(), cancellationToken);
        return result.AsAspNetCoreResult();
    }

    [HttpGet("orders/{order_id:guid}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetOrderById([FromRoute] Guid order_id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetOrderByIdRequest(order_id), cancellationToken);
        return result.AsAspNetCoreResult();
    }


    [HttpPost("orders/{order_id:guid}/bookings")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBookings([FromRoute] Guid order_id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetBookingsRequest(order_id), cancellationToken);
        return result.AsAspNetCoreResult();
    }

    [HttpPost("orderfs/{order_id:guid}/delivery")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> SetTime([FromRoute] Guid order_id, [FromQuery] int number,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new SetTimeRequest {OrderId = order_id, SlotNumber = number}, cancellationToken);
        return result.AsAspNetCoreResult();
    }

    [HttpPut("orders/{order_id:guid}/items/{item_id:guid}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> PutItem([FromQuery] int amount, [FromRoute] Guid item_id, [FromRoute] Guid order_id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new PutItemRequest {OrderId = order_id, Amount = amount, ItemId = item_id }, cancellationToken);
        return result.AsAspNetCoreResult();
    }

    [HttpPost("orders/{order_id:guid}/payment")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Pay([FromRoute] Guid order_id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new PayRequest {OrderId = order_id}, cancellationToken);
        return result.AsAspNetCoreResult();
    }
}