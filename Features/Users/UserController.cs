using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Features.Common;
using ShopAPI.Features.Deliveries.RequestHandling.Dto;
using ShopAPI.Features.Deliveries.RequestHandling.Requests;
using ShopAPI.Features.RequestHandling.Base;
using ShopAPI.Features.Users.RequestHandling.Dto;
using ShopAPI.Features.Users.RequestHandling.Requests;

namespace ShopAPI.Features.Users;

[Route("api/v1/[controller]")]
[ApiVersion("1.0")]
public class UsersController : BaseApiController
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }


    /// <summary>
    ///     Reg user
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> RegUser([FromBody] UserDto dto,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new RegUserRequest(dto.Username, dto.Password), cancellationToken);
        return result.AsAspNetCoreResult();
    }

    /// <summary>
    ///     Auth user
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("authentication")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> AuthUser([FromBody] UserDto dto,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new AuthUserRequest(dto.Username, dto.Password), cancellationToken);
        return result.AsAspNetCoreResult();
    }

    /// <summary>
    ///     Refresh token
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("authentication/refresh")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> RefreshToken([FromHeader] Guid accessToken, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new RefreshTokenRequest(accessToken), cancellationToken);
        return result.AsAspNetCoreResult();
    }

    /// <summary>
    ///     Refresh token
    /// </summary>
    /// <param name="user_id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{user_id:guid}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetUser([FromRoute] Guid user_id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserByIdRequest {UserId = user_id }, cancellationToken);
        return result.AsAspNetCoreResult();
    }
}