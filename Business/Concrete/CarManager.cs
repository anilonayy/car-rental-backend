using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Exceptions;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarDTOs;
using Entities.DTOs.CarImageDTOs;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly ICarImageService _carImageService;
        private readonly IMapper _mapper;
        public CarManager(ICarDal carDal, ICarImageService carImageService, IMapper mapper)
        {
            _carDal = carDal;
            _carImageService = carImageService;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CarValidator))]
        [TransactionScopeAspect]
        public IResult<Car> Create(Car entity)
        {
            _carDal.Create(entity);
            return new CreatedResult<Car>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, entity);
        }

        public IResult<Car> Delete(int id)
        {
            _carDal.Delete(_carDal.Get(c => c.Id == id));
            _carImageService.DeleteByCarAsync(id);

            return new NoContentResult<Car>();
        }

        public IResult<Car> Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult<Car>(OperationMessages.SuccessTitle,OperationMessages.SuccessMessage,car);
        }

        public IResult<CarDetailDto> GetById(int id)
        {
            var car = _carDal.GetWithDetails(p => p.Id == id).FirstOrDefault();

            if( car == null)
            {
                throw new NotFoundException(OperationMessages.NotFound);
            }
            return new SuccessResult<CarDetailDto>(OperationMessages.SuccessTitle,OperationMessages.SuccessMessage,car);
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
