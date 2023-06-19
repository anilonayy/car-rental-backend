using System.Text.Json.Serialization;

namespace Entities.DTOs.RentalDTOs
{
    public class RentalCreateDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
    }
}
