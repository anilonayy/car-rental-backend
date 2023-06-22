using Core.Entities.Abstract;

namespace Entities.DTOs.UserDTOs
{
    public class UserDetailDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
