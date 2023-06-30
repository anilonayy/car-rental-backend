using Entities.Concrete;

namespace Entities.DTOs.PaymentDTOs
{
    public class PaymentCreateDto
    {
        public string CreditCardNumber { get; set; }
        public string ExpireDate { get; set; }
        public int SecurityCode { get; set; }
        public decimal Price { get; set; }
        public int RentalId { get; set; }
    }
}
