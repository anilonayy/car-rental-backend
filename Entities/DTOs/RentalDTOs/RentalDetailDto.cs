namespace Entities.DTOs.RentalDTOs
{
    public class RentalDetailDto
    {
        public int Id { get; set; }
        public int CarName { get; set; }
        public int CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
