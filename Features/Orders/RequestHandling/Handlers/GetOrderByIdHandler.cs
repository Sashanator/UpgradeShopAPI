using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ShopAPI.Features.Orders.RequestHandling.Requests;
using ShopAPI.Features.Orders.Services;
using ShopAPI.Features.RequestHandling.Base;

namespace ShopAPI.Features.Orders.RequestHandling.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, Response>
    {
        private readonly IOrderService _orderService;
        public GetOrderByIdHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<Response> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _orderService.GetOrderById(request.OrderId, cancellationToken);
                return Response.Ok(request.Id, result);
            }
            catch (Exception e)
            {
                return Response.InternalServerError(request.Id, e);
            }
        }
    }
}
