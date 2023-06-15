using Business.Abstract;
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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _carDal.Get(filter);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _carDal.GetAll(filter);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<CarDetailDto> GetWithDetails()
        {
            return _carDal.GetWithDetails();
        }

        public void Update(Car entity)
        {
            _carDal.Update(entity);
        }
    }
}
