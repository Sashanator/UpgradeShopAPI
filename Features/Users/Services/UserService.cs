using ShopAPI.Features.DataAccess.Repositories;
using ShopAPI.Features.Users.Model;

namespace ShopAPI.Features.Users.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task RegUser(string username, string password, CancellationToken cancellationToken)
    {
        var accessToken = Guid.NewGuid();
        var refreshToken = Guid.NewGuid();
        var user = new User
        {
            Username = username,
            Password = password,
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
        await _unitOfWork.UserRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<Guid> AuthUser(string username, string password, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.UserRepository.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        return result.AccessToken;
    }

    public async Task<Guid> RefreshToken(Guid token, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.UserRepository.FirstOrDefaultAsync(u => u.RefreshToken == token);
        var newToken = Guid.NewGuid();
        result.AccessToken = newToken;
        await _unitOfWork.UserRepository.UpdateAsync(result);
        await _unitOfWork.SaveChangesAsync();
        return newToken;
    }

    public async Task<User> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.UserRepository.GetByIdAsync(id);
        return result;
    }
}