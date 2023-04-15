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
    public class PayHandler : IRequestHandler<PayRequest, Response>
    {
        private readonly IBombardierService _bombardierService;

        public PayHandler(IBombardierService bombardierService)
        {
            _bombardierService = bombardierService;
        }

        public async Task<Response> Handle(PayRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _bombardierService.Pay(request.OrderId, cancellationToken);
                return Response.Ok(request.Id);
            }
            catch (Exception e)
            {
                return Response.InternalServerError(request.Id, e);
            }
        }
    }
}
