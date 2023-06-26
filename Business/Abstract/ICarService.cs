using Core.Entities.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CarDTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        ICustomResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        ICustomResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
        ICustomResult<List<CarDetailDto>> GetWithDetails();

        ICustomResult<CarDetailDto> GetById(int carId);
        ICustomResult<Car> Create(Car car);
        ICustomResult<Car> Update(Car car);
        ICustomResult<Car> Delete(int id);


    }


}
