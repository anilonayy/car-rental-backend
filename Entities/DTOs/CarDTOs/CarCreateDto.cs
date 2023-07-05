using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.CarDTOs
{
    public class CarCreateDto : IDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
