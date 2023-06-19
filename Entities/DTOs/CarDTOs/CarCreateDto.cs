using Core.Entities;
using System.Text.Json.Serialization;

namespace Entities.DTOs.CarDTOs
{
    public class CarCreateDto : IDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
