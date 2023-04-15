using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAPI.Features.Users.Model;

namespace ShopAPI.Features.Users.Services;

public interface IUserService
{
    Task RegUser(string username, string password, CancellationToken cancellationToken);

    Task<Guid> AuthUser(string username, string password, CancellationToken cancellationToken);

    Task<Guid> RefreshToken(Guid token, CancellationToken cancellationToken);

    Task<User> GetUserById(Guid id, CancellationToken cancellationToken);
}