using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileTools;
using Core.Utilities.Functions;
using Core.Utilities.Messages;
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

        public async Task<IResult<CarImage>> CreateAsync(CarImageAddDto dto)
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

                return new SuccessResult<CarImage>(OperationMessages.SuccessMessage, OperationMessages.SuccessMessage, entity);
            }
        }


        public async Task<IResult<CarImage>> Delete(int id)
        {
            var image = _carImageDal.Get(c => c.Id == id);

            _carImageDal.Delete(image);
            await FileOperations.DeleteAsync(image.ImagePath);

            return new NoContentResult<CarImage>();
        }

        public IResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessResult<List<CarImage>>(OperationMessages.SuccessMessage, OperationMessages.SuccessMessage, _carImageDal.GetAll(filter));
        }

        public IResult<CarImage> GetById(int id)
        {
            return new SuccessResult<CarImage>(OperationMessages.SuccessMessage, OperationMessages.SuccessMessage, _carImageDal.Get(c => c.Id == id));
        }

        public async Task<IResult<List<CarImage>>> GetImagesByCarId(int carId)
        {
            var images = _carImageDal.GetByCar(carId);


            if (images.Count == 0)
            {
                images.Add(new CarImage { ImagePath = _uriFunctions.GetHostUrl() + "uploads/logo.png" });
            }


            return new SuccessResult<List<CarImage>>(OperationMessages.SuccessMessage, OperationMessages.SuccessMessage, images);
        }

        public async Task<IResult<CarImage>> UpdateAsync(CarImageUpdateDto dto)
        {
            var target = _carImageDal.Get(x => x.Id == dto.Id);


            await FileOperations.DeleteAsync(target.ImagePath);
            var result = await FileOperations.UploadAsync(dto.ImageFile, "uploads/car-images/");

            target.ImagePath = result;
            target.Date = DateTime.Now;

            _carImageDal.Update(target);


            return new SuccessResult<CarImage>(OperationMessages.SuccessMessage, OperationMessages.SuccessMessage, target);
        }


        private IResult<CarImage> IsMaximumPhotoCount(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId).Count >= 5;

            if (result)
            {
                return new ErrorResult<CarImage>(OperationMessages.ErrorTitle,Messages.CarImageMaximumLengthError);
            }
            return new SuccessResult<CarImage>(OperationMessages.SuccessMessage, OperationMessages.SuccessMessage);
        }
    }
}
