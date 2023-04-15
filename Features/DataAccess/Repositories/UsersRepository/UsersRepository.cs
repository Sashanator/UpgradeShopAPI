using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAPI.Features.Users.Model;

namespace ShopAPI.Features.DataAccess.Repositories.UsersRepository
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(ShopDbContext context, IHttpContextAccessor contextAccessor) : base(context, contextAccessor) { }
    }
}
