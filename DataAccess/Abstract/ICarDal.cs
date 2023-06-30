using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.CarDTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    // generic contraint
    // class   : reference type
    // IEntity : Can be IEntity interface or implemented from IEntity interface
    // new()   : Can be newable
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetWithDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        List<CarDetailDto> GetWithDetailsByFilter(int? colorId,int? brandId);
    }
}
