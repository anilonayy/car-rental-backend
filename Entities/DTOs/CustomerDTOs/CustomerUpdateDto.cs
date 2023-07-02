using Core.Entities.Abstract;

namespace Entities.DTOs.CustomerDTOs
{
    public class CustomerUpdateDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
