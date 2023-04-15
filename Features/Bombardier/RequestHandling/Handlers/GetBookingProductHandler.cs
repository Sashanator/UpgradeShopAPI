﻿using System;
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
    public class GetBookingProductHandler : IRequestHandler<GetBookingProductRequest, Response>
    {
        private readonly IBombardierService _bombardierService;
        public GetBookingProductHandler(IBombardierService bombardierService)
        {
            _bombardierService = bombardierService;
        }

        public async  Task<Response> Handle(GetBookingProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _bombardierService.GetBookingProduct(request.BookingId, cancellationToken);
                return Response.Ok(request.Id, result);
            }
            catch (Exception e)
            {
                return Response.InternalServerError(request.Id, e);
            }
        }
    }
}
