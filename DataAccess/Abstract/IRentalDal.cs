using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.RentalDTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalsWithDetail();
        Rental GetRentalWithDetail(int rentalId);
    }
}
