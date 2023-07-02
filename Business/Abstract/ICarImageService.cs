using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CarImageDTOs;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        ICustomResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null);
        ICustomResult<CarImage> GetById(int id);
        Task<ICustomResult<CarImage>> CreateAsync(CarImageAddDto entity);
        Task<ICustomResult<CarImage>> Delete(int id);
        Task<ICustomResult<CarImage>> UpdateAsync(CarImageUpdateDto dto);
        Task<ICustomResult<List<CarImage>>> GetImagesByCarId(int carId);
    }
}
