using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpireDate { get; set; }
        public int SecurityCode { get; set; }
        public decimal Price { get; set; }
        public int RentalId { get; set; }
        public Rental Rental { get; set; }
    }
}
