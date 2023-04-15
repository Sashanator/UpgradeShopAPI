using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ShopAPI.Features.RequestHandling.Base;
using ShopAPI.Features.Users.RequestHandling.Requests;
using ShopAPI.Features.Users.Services;

namespace ShopAPI.Features.Users.RequestHandling.Handlers
{
    public class RegUserHandler : IRequestHandler<RegUserRequest, Response>
    {
        private readonly IUserService _userService;

        public RegUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Response> Handle(RegUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _userService.RegUser(request.Username, request.Password, cancellationToken);
                return Response.Ok(request.Id);
            }
            catch (Exception e)
            {
                return Response.InternalServerError(request.Id, e);
            }
        }
    }
}
