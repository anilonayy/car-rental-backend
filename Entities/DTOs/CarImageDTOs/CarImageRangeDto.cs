using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.CarImageDTOs
{
    public class CarImageRangeDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public List<IFormFile>? ImageFiles { get; set; }

    }
}

