using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.RentalDTOs;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IRentalService
    {
        ICustomResult<Rental> Update(Rental entity);
        ICustomResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null);
        ICustomResult<Rental> GetById(int id);
        ICustomResult<Rental> Delete(int id);
        ICustomResult<Rental> Create(RentalCreateDto entity);


        ICustomResult<List<RentalDetailDto>> GetRentalsWithDetail();
        ICustomResult<RentalDetailDto> GetRentalWithDetail(int rentalId);
    }
}
