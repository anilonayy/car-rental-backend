using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime PlannedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public byte IsPaid { get; set; }
    }
}
