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
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, Response>
    {
        private readonly IUserService _userService;
        public GetUserByIdHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Response> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.GetUserById(request.UserId, cancellationToken);
                return Response.Ok(request.Id, result);
            }
            catch (Exception e)
            {
                return Response.InternalServerError(request.Id, e);
            }
        }
    }
}
