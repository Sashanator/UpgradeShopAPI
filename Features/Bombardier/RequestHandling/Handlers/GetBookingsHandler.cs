using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ShopAPI.Features.Bombardier.RequestHandling.Requests;
using ShopAPI.Features.Bombardier.Services;
using ShopAPI.Features.RequestHandling.Base;

namespace ShopAPI.Features.Bombardier.RequestHandling.Handlers
{
    public class GetBookingsHandler : IRequestHandler<GetBookingsRequest, Response>
    {
        private readonly IBombardierService _bombardierService;

        public GetBookingsHandler(IBombardierService bombardierService)
        {
            _bombardierService = bombardierService;
        }

        public async Task<Response> Handle(GetBookingsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _bombardierService.GetBookings(request.OrderId, cancellationToken);
                return Response.Ok(request.Id);
            }
            catch (Exception e)
            {
                return Response.InternalServerError(request.Id, e);
            }
        }
    }
}
