using Core.Entities.Abstract;

namespace Entities.DTOs.ColorDTOs
{
    public class ColorUpdateDto : IDto
    {
        public int ColorId { get; set; }
        public string Name { get; set; }
    }
}
