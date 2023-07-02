using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileTools;
using Core.Utilities.Functions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarImageDTOs;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        readonly ICarImageDal _carImageDal;
        readonly IUriFunctions _uriFunctions;

        public CarImageManager(ICarImageDal carImageDal, IUriFunctions uriFunctions)
        {
            _carImageDal = carImageDal;
            _uriFunctions = uriFunctions;
        }

        public async Task<ICustomResult<CarImage>> CreateAsync(CarImageAddDto dto)
        {
            var ruleResult = BusinessRules.Run(IsMaximumPhotoCount(dto.CarId));

            if (ruleResult != null)
            {
                return ruleResult;
            }
            else
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

                return new SuccessResult<CarImage>(201, entity);
            }
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
            return new SuccessResult<List<CarImage>>(200, _carImageDal.GetAll(filter));
        }

        public ICustomResult<CarImage> GetById(int id)
        {
            return new SuccessResult<CarImage>(200, _carImageDal.Get(c => c.Id == id));
        }

        public async Task<ICustomResult<List<CarImage>>> GetImagesByCarId(int carId)
        {
            var images = _carImageDal.GetByCar(carId);


            if (images.Count == 0)
            {
                images.Add(new CarImage { ImagePath = _uriFunctions.GetHostUrl() + "uploads/logo.png" });
            }


            return new SuccessResult<List<CarImage>>(200, images);
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


        private ICustomResult<CarImage> IsMaximumPhotoCount(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId).Count >= 5;

            if (result)
            {
                return new ErrorResult<CarImage>(400, Messages.CarImageMaximumLengthError);
            }
            return new SuccessResult<CarImage>(200);
        }
    }
}
