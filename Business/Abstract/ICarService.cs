using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CarDTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
        IResult<List<CarDetailDto>> GetWithDetails();

        IResult<CarDetailDto> GetById(int carId);
        IResult<Car> Create(Car car);
        IResult<Car> Update(Car car);
        IResult<Car> Delete(int id);
        IResult<List<CarDetailDto>> GetByColorAndBrand(int colorId, int brandId);
    }


}
