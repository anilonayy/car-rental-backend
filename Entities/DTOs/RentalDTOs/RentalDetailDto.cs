using Entities.DTOs.CarDTOs;

namespace Entities.DTOs.RentalDTOs
{
    public class RentalDetailDto
    {
        public int Id { get; set; }
        public CarDetailDto CarDetail { get; set; }
        public string CustomerName { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
