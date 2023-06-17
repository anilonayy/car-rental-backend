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
        public void Create(Car entity)
        {
            if (entity.Description.Length < 2)
            {
                Console.WriteLine("Araba adı en az 2 karakter olmalıdır.");
                return;
            }

            else if (entity.DailyPrice <= 0)
            {
                Console.WriteLine("Araba günlük kiralama fiyatı 0 'dan büyük olmalıdır.");
                return;
            }
            else
            {
                _carDal.Create(entity);
                Console.WriteLine("Araba başarıyla eklendi!");
            }
        }

        public void Delete(Car entity)
        {
            _carDal.Delete(entity);
        }

        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter)
        {
            return new SuccessDataResult<Car>(_carDal.Get(filter));
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

        public void Update(Car entity)
        {
            _carDal.Update(entity);
        }
    }
}
