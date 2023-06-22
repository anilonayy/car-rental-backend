using Core.Entities.Abstract;
using System.Text.Json.Serialization;

namespace Entities.DTOs.ColorDTOs
{
    public class ColorCreateDto : IDto
    {
        [JsonIgnore]
        public int ColorId { get; set; }
        public string Name { get; set; }
    }
}
