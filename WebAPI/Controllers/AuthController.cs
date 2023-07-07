using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    public class AuthController : CustomControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);

            if (!userToLogin.success)
            {
                return  CreateResponse(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.data);
            if (result.success)
            {
                var userRes = new UserLoginResponseDto
                {
                    Email = userToLogin.data.Email,
                    FirstName = userToLogin.data.FirstName,
                    LastName = userToLogin.data.LastName,
                    Token = result.data.Token,
                    Expiration = result.data.Expiration
                };

                var succressResult = new SuccessResult<UserLoginResponseDto>("Success","Logged in",userRes);
                return CreateResponse(succressResult);
            }

            return CreateResponse(userToLogin);
        }

        [HttpPost("register")]
        public ActionResult Register(UserRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.success)
            {
                return BadRequest(userExists);
            }

            var registerResult = _authService.Register(userForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.data);
            if (result.success)
            {
                return CreateResponse(result);
            }

            return CreateResponse(result);
        }
    }
}
