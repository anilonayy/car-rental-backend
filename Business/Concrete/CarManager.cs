using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        public IDataResult<Car> Create(Car entity)
        {
            if (entity.Description.Length < 2)
            {
                return new ErrorDataResult<Car>(default, "Araba adı en az 2 karakter olmalıdır.");
            }

            else if (entity.DailyPrice <= 0)
            {
                return new ErrorDataResult<Car>(default, "Araba günlük kiralama fiyatı 0 'dan büyük olmalıdır.");
            }
            else
            {
                _carDal.Create(entity);
                return new SuccessDataResult<Car>(entity,"Araç Başarıyla Eklendi.");
            }
        }

        public IResult Delete(int id)
        {
            _carDal.Delete( _carDal.Get(c => c.Id==id ));
            return new SuccessResult();
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id==id));
        }

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(filter));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetWithDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetWithDetails());
        }

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);

            return new SuccessResult();
        }
    }
}
