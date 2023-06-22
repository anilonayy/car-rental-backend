using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs.UserDTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        ICustomResult<User> Register(UserRegisterDto userRegisterDto);
        ICustomResult<User> Login(UserLoginDto userLoginDto);
        ICustomResult<User> UserExists(string email);
        ICustomResult<AccessToken> CreateAccessToken(User user);
    }
}
