using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.RentalDTOs;

namespace Business.Abstract
{
    public interface IRentalService : IGenericService<Rental>
    {
        ICustomResult<List<RentalDetailDto>> GetRentalsWithDetail();
    }
}
