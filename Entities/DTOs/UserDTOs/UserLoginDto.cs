using Core.Entities.Abstract;

namespace Entities.DTOs.UserDTOs
{
    public class UserLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
