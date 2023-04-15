using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAPI.Features.RequestHandling.Base;

namespace ShopAPI.Features.Users.RequestHandling.Requests
{
    public class GetUserByIdRequest : Request<Response>
    {
        public Guid UserId { get; set; }
    }
}
