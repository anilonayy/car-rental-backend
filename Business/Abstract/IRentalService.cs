using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.RentalDTOs;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult<Rental> Update(Rental entity);
        IResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null);
        IResult<Rental> GetById(int id);
        IResult<Rental> Delete(int id);
        IResult<Rental> Create(RentalCreateDto entity);


        IResult<List<RentalDetailDto>> GetRentalsWithDetail();
        IResult<RentalDetailDto> GetRentalWithDetail(int rentalId);
    }
}
