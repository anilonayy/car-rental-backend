using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        readonly IRentalDal _rentalDal;
        readonly ICarDal _carDal;

        public RentalManager(IRentalDal rentalDal,ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
        }

        public IDataResult<Rental> Create(Rental entity)
        {
            var isCarAvailable = _rentalDal.Get(r => r.CarId == entity.CarId && r.ReturnDate == null);


            // If car is not available right now
            if(isCarAvailable != null)
                return new ErrorDataResult<Rental>(default, "Car is not available for rental right now.");
            



            _rentalDal.Create(entity);
            return new SuccessDataResult<Rental>(entity);

        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id==id));
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(filter));
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult();
        }
    }
}
