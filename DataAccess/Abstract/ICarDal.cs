using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.CarDTOs;

namespace DataAccess.Abstract
{
    // generic contraint
    // class   : reference type
    // IEntity : Can be IEntity interface or implemented from IEntity interface
    // new()   : Can be newable
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetWithDetails();
    }
}
