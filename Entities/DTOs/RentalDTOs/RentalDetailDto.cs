using Entities.DTOs.CarDTOs;
using Entities.DTOs.UserDTOs;

namespace Entities.DTOs.RentalDTOs
{
    public class RentalDetailDto
    {
        public int Id { get; set; }
        public CarDetailDto Car { get; set; }
        public UserDetailDto User { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
