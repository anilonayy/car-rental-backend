using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs.CarDTOs
{
    public class CarDetailDto : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public Brand Brand { get; set; }
        public Color Color { get; set; }
        public string CoverImage { get; set; }
    }
}
