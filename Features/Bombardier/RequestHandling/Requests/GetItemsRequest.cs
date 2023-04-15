using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAPI.Features.RequestHandling.Base;

namespace ShopAPI.Features.Bombardier.RequestHandling.Requests
{
    public class GetItemsRequest : Request<Response>
    {
        public GetItemsRequest(Guid orderId)
        {
            OrderId = orderId;
        }
        public Guid OrderId { get; set; }
    }
}
