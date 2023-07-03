using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarDTOs;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;


        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult<Car> Create(Car entity)
        {

            _carDal.Create(entity);
            return new CreatedResult<Car>(OperationMessages.SuccessTitle,OperationMessages.SuccessMessage,entity);

        }

        public IResult<Car> Delete(int id)
        {
            _carDal.Delete(_carDal.Get(c => c.Id == id));
            return new NoContentResult<Car>();
        }

        public IResult<Car> Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult<Car>(OperationMessages.SuccessTitle,OperationMessages.SuccessMessage,car);
        }

        public IResult<CarDetailDto> GetById(int id)
        {
            return new SuccessResult<CarDetailDto>(OperationMessages.SuccessTitle,OperationMessages.SuccessMessage, _carDal.GetWithDetails(p => p.Id == id).FirstOrDefault());
        }

        public IResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            var data = _carDal.GetAll(filter);
            return new SuccessResult<List<Car>>(OperationMessages.SuccessTitle,OperationMessages.SuccessTitle,data);
        }

        public IResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessResult<List<CarDetailDto>>(OperationMessages.SuccessTitle, OperationMessages.SuccessTitle, _carDal.GetWithDetails(c => c.Brand.BrandId == brandId));
        }

        public IResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessResult<List<CarDetailDto>>(OperationMessages.SuccessTitle,OperationMessages.SuccessTitle, _carDal.GetWithDetails(c => c.Color.ColorId == colorId));
        }

        public IResult<List<CarDetailDto>> GetWithDetails()
        {
            return new SuccessResult<List<CarDetailDto>>(OperationMessages.SuccessTitle,OperationMessages.SuccessTitle, _carDal.GetWithDetails());
        }

        public IResult<List<CarDetailDto>> GetByColorAndBrand(int colorId, int brandId)
        {
            return new SuccessResult<List<CarDetailDto>>(OperationMessages.SuccessTitle,OperationMessages.SuccessTitle, _carDal.GetWithDetailsByFilter(colorId, brandId));
        }
    }
}
