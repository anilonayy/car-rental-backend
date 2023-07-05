using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CarImageDTOs;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null);
        IResult<CarImage> GetById(int id);
        Task<IResult<CarImage>> CreateAsync(CarImageAddDto entity);
        Task<IResult<List<CarImage>>> CreateRangeAsync(CarImageRangeDto entity);
        Task<IResult<CarImage>> Delete(int id);
        Task<IResult<CarImage>> UpdateAsync(CarImageUpdateDto dto);
        Task<IResult<List<CarImage>>> GetImagesByCarId(int carId);
        Task<IResult<CarImage>> DeleteByCarAsync(int id);
    }
}
