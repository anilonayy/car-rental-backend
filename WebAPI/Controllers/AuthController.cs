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
            if (!userToLogin.success)
            {
                return BadRequest(userToLogin.errors);
            }

            var result = _authService.CreateAccessToken(userToLogin.data);
            if (result.success)
            {
                return Ok(result.data);
            }

            return BadRequest(result.errors);
        }

        [HttpPost("register")]
        public ActionResult Register(UserRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.success)
            {
                return BadRequest(userExists.errors);
            }

            var registerResult = _authService.Register(userForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.data);
            if (result.success)
            {
                return Ok(result.data);
            }

            return BadRequest(result.errors);
        }
    }
}
