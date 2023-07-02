using Entities.DTOs.UserDTOs;

namespace Entities.DTOs.CustomerDTOs
{
    public class CustomerDetailDto
    {
        public int Id { get; set; }
        public UserDetailDto UserDetails { get; set; }
        public string CompanyName { get; set; }


    }
}
