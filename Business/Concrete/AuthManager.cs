using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs.UserDTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        readonly IUserService _userService;
        readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessResult<AccessToken>(OperationMessages.SuccessTitle,OperationMessages.SuccessMessage ,accessToken);
        }

        public IResult<User> Login(UserLoginDto userLoginDto)
        {
            var userToCheck = _userService.GetByMail(userLoginDto.Email).data;
            if (userToCheck == null)
            {
                return new ErrorResult<User>(OperationMessages.ErrorTitle,Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorResult<User>(OperationMessages.ErrorTitle, Messages.PasswordError);
            }

            return new SuccessResult<User>(OperationMessages.SuccessTitle,OperationMessages.SuccessMessage, userToCheck);
        }

        public IResult<User> Register(UserRegisterDto userRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.HashPassword(userRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User()
            {
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Create(user);

            return new SuccessResult<User>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, user);
        }

        public IResult<User> UserExists(string email)
        {
            var result = _userService.GetByMail(email);

            if (result.success)
            {
                return new ErrorResult<User>(OperationMessages.ErrorTitle, Messages.UserAlreadyExists);
            }
            else
            {
                return new NoContentResult<User>();
            }

        }
    }
}
