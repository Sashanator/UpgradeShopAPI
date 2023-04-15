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
    public class GetPayLogHandler : IRequestHandler<GetPayLogRequest, Response>
    {
        private readonly IBombardierService _bombardierService;

        public GetPayLogHandler(IBombardierService bombardierService)
        {
            _bombardierService = bombardierService;
        }

        public async Task<Response> Handle(GetPayLogRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _bombardierService.GetPayLog(request.OrderId, cancellationToken);
                return Response.Ok(request.Id, result);
            }
            catch (Exception e)
            {
                return Response.InternalServerError(request.Id, e);
            }
        }
    }
}
