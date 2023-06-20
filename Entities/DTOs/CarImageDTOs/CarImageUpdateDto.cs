using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.CarImageDTOs
{
    public class CarImageUpdateDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
