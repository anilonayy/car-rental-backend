using Core.Entities;
using System.Text.Json.Serialization;

namespace Entities.DTOs.BrandDTOs
{
    public class BrandCreateDto : IDto
    {
        [JsonIgnore]
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
