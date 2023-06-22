using Core.Entities.Abstract;
using System.Text.Json.Serialization;

namespace Entities.DTOs.ColorDTOs
{
    public class ColorUpdateDto : IDto
    {
        public int ColorId { get; set; }
        public string Name { get; set; }
    }
}
