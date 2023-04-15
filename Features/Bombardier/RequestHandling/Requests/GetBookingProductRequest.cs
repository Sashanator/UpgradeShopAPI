using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAPI.Features.RequestHandling.Base;

namespace ShopAPI.Features.Bombardier.RequestHandling.Requests
{
    public class GetBookingProductRequest : Request<Response>
    {
        public GetBookingProductRequest(Guid bookingId)
        {
            BookingId = bookingId;
        }
        public Guid BookingId { get; set; }
    }
}
