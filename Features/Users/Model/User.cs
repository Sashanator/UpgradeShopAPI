using ShopAPI.Features.DataAccess.Models;

namespace ShopAPI.Features.Users.Model;

public class User : BaseEntity
{
    public string Username { get; set; }

    public string Password { get; set; }

    public Guid AccessToken { get; set; }

    public Guid RefreshToken { get; set; } 
}