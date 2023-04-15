﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAPI.Features.RequestHandling.Base;

namespace ShopAPI.Features.Users.RequestHandling.Requests
{
    public class AuthUserRequest : Request<Response>
    {
        public AuthUserRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
