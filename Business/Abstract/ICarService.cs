using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService : IGenericService<Car>
    {
        ICustomResult<List<Car>> GetCarsByBrandId(int brandId);
        ICustomResult<List<Car>> GetCarsByColorId(int colorId);
        ICustomResult<List<CarDetailDto>> GetWithDetails();
    }
}
