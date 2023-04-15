using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAPI.Features.RequestHandling.Base;

namespace ShopAPI.Features.Users.RequestHandling.Requests
{
    public class RefreshTokenRequest : Request<Response>
    {
        public RefreshTokenRequest(Guid accessToken)
        {
            AccessToken = accessToken;
        }
        public Guid AccessToken { get; set; }
    }
}
