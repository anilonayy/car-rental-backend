using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        public ICustomResult<Car> Create(Car entity)
        {
            
                _carDal.Create(entity);
                return new SuccessResult<Car>(201,entity);
          
        }

        public ICustomResult<Car> Delete(int id)
        {
            _carDal.Delete( _carDal.Get(c => c.Id==id ));
            return new SuccessResult<Car>(204);
        }

        public ICustomResult<Car> Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult<Car>(204);
        }

        public ICustomResult<CarDetailDto> GetById(int id)
        {
            return new SuccessResult<CarDetailDto>(200,_carDal.GetWithDetails(p => p.Id==id).FirstOrDefault());
        }

        public ICustomResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            var data =  _carDal.GetAll(filter);
            return new SuccessResult<List<Car>>(200,data);
        }

        public ICustomResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessResult<List<CarDetailDto>>(200,_carDal.GetWithDetails(c => c.BrandId == brandId));
        }

        public ICustomResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessResult<List<CarDetailDto>>(200,_carDal.GetWithDetails(c => c.ColorId == colorId));
        }

        public ICustomResult<List<CarDetailDto>> GetWithDetails()
        {
            return new SuccessResult<List<CarDetailDto>>(200,_carDal.GetWithDetails());
        }

        public ICustomResult<List<CarDetailDto>> GetByColorAndBrand(int colorId,int brandId)
        {
            return new SuccessResult<List<CarDetailDto>>(200, _carDal.GetWithDetails(c => c.ColorId==colorId && c.BrandId==brandId));
        }
    }
}
