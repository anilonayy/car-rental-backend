using Core.Entities;
using System.Text.Json.Serialization;

namespace Entities.DTOs.CustomerDTOs
{
    public class CustomerCreateDto : IDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
