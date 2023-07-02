using Core.Entities.Abstract;

namespace Entities.DTOs.BrandDTOs
{
    public class BrandUpdateDto : IDto
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
