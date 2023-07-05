using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Exceptions;
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
            var ruleResult = BusinessRules.Run(IsMaximumPhotoCount(dto.CarId,1));

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
                    ImagePath =  result,
                    Date = DateTime.Now,
                    Id = dto.Id
                };


                _carImageDal.Create(entity);

                entity.ImagePath += _uriFunctions.GetHostUrl();


                return new SuccessResult<CarImage>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, entity);
            }
        }

        [TransactionScopeAspect]
        public async Task<IResult<List<CarImage>>> CreateRangeAsync(CarImageRangeDto dto)
        {
            var ruleResult = BusinessRules.Run(IsMaximumPhotoCount(dto.CarId,dto.ImageFiles.Count));

            String result = "";
            CarImage entity = new CarImage();

            List<CarImage> CarImageList = new List<CarImage>();

            if (ruleResult != null)
            {
                throw new ClientSideException(ruleResult.message);
            }
            else
            {
                foreach(var photo in dto.ImageFiles)
                {
                     result = await FileOperations.UploadAsync(photo, "uploads/car-images/");
                     entity = new CarImage
                    {
                        CarId = dto.CarId,
                        ImagePath =  result,
                        Date = DateTime.Now,

                    };

                    _carImageDal.Create(entity);
                    entity.ImagePath = _uriFunctions.GetHostUrl() + entity.ImagePath;
                    CarImageList.Add(entity);

                }
                return new SuccessResult<List<CarImage>>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, CarImageList);
            }
        }


        public async Task<IResult<CarImage>> Delete(int id)
        {
            var image = _carImageDal.Get(c => c.Id == id);

            _carImageDal.Delete(image);
            await FileOperations.DeleteAsync(image.ImagePath);

            return new NoContentResult<CarImage>();
        }

        public async Task<IResult<CarImage>> DeleteByCarAsync(int id)
        {
            var images = _carImageDal.GetAll(i => i.CarId == id);

            if(images!=null)
            {
                foreach(var image in images)
                {
                    _carImageDal.Delete(image);
                    await FileOperations.DeleteAsync(image.ImagePath);
                }
            }

            return new SuccessResult<CarImage>(OperationMessages.SuccessTitle,OperationMessages.SuccessMessage);
        }

        public IResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessResult<List<CarImage>>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, _carImageDal.GetAll(filter));
        }

        public IResult<CarImage> GetById(int id)
        {
            return new SuccessResult<CarImage>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, _carImageDal.Get(c => c.Id == id));
        }

        public async Task<IResult<List<CarImage>>> GetImagesByCarId(int carId)
        {
            var images = _carImageDal.GetByCar(carId);


            if (images.Count == 0)
            {
                images.Add(new CarImage { ImagePath = _uriFunctions.GetHostUrl() + "uploads/logo.png" });
            }


            return new SuccessResult<List<CarImage>>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, images);
        }

        public async Task<IResult<CarImage>> UpdateAsync(CarImageUpdateDto dto)
        {
            var target = _carImageDal.Get(x => x.Id == dto.Id);


            await FileOperations.DeleteAsync(target.ImagePath);
            var result = await FileOperations.UploadAsync(dto.ImageFile, "uploads/car-images/");

            target.ImagePath = result;
            target.Date = DateTime.Now;

            _carImageDal.Update(target);


            return new SuccessResult<CarImage>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, target);
        }


        private IResult<CarImage> IsMaximumPhotoCount(int carId,int willAdd)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId).Count + willAdd > 5;

            if (result)
            {
                return new ErrorResult<CarImage>(OperationMessages.ErrorTitle,Messages.CarImageMaximumLengthError);
            }
            return new SuccessResult<CarImage>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage);
        }
    }
}
