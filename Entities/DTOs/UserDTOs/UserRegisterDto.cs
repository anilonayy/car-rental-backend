using Core.Entities.Abstract;

namespace Entities.DTOs.UserDTOs
{
    public class UserRegisterDto : IDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
