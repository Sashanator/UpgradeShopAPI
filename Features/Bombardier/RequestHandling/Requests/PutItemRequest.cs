using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAPI.Features.RequestHandling.Base;

namespace ShopAPI.Features.Bombardier.RequestHandling.Requests
{
    public class PutItemRequest : Request<Response>
    {
        public int Amount { get; set; }

        public Guid ItemId { get; set; }

        public Guid OrderId { get; set; }
    }
}
