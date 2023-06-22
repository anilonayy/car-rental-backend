using Business.Abstract;
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
            if (!userToLogin.isSuccess)
            {
                return BadRequest(userToLogin.Errors);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.isSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("register")]
        public ActionResult Register(UserRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.isSuccess)
            {
                return BadRequest(userExists.Errors);
            }

            var registerResult = _authService.Register(userForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.isSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Errors);
        }
    }
}
