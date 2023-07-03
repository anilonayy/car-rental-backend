using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs.UserDTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IResult<User> Register(UserRegisterDto userRegisterDto);
        IResult<User> Login(UserLoginDto userLoginDto);
        IResult<User> UserExists(string email);
        IResult<AccessToken> CreateAccessToken(User user);
    }
}
