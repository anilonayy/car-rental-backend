using Core.Entities;
using System.Text.Json.Serialization;

namespace Entities.DTOs.UserDTOs
{
    public class UserCreateDto : IDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
