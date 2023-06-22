using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace Entities.DTOs.CarImageDTOs
{
    public class CarImageAddDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
