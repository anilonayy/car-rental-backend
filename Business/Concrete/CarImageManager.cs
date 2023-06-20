using Business.Abstract;
using Core.Utilities.FileTools;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarImageDTOs;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public async Task<ICustomResult<CarImage>> CreateAsync(CarImageAddDto dto)
        {

            var result = await FileOperations.UploadAsync(dto.ImageFile, "uploads/car-images/");

            var entity = new CarImage
            {
                CarId = dto.CarId,
                ImagePath = result,
                Date = DateTime.Now,
                Id = dto.Id
            };


            _carImageDal.Create(entity);

            return new SuccessResult<CarImage>(201,entity);
        }
        

        public async Task<ICustomResult<CarImage>> Delete(int id)
        {
            var image = _carImageDal.Get(c => c.Id == id);

            _carImageDal.Delete(image);
             await FileOperations.DeleteAsync(image.ImagePath);

            return new SuccessResult<CarImage>(204);
        }

        public ICustomResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessResult<List<CarImage>>(200, _carImageDal.GetAll(filter) );
        }

        public ICustomResult<CarImage> GetById(int id)
        {
            throw new NotImplementedException();
        }

   

        public async Task<ICustomResult<CarImage>> UpdateAsync(CarImageUpdateDto dto)
        {
            var target = _carImageDal.Get(x => x.Id == dto.Id);


            await FileOperations.DeleteAsync(target.ImagePath);
            var result = await FileOperations.UploadAsync(dto.ImageFile, "uploads/car-images/");

            target.ImagePath = result;
            target.Date = DateTime.Now;

            _carImageDal.Update(target);
        

            return new SuccessResult<CarImage>(200, target);
        }
    }
}
