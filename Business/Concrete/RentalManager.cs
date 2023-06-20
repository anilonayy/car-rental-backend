using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public ICustomResult<Rental> Create(Rental entity)
        {
            var isCarAvailable = _rentalDal.Get(r => r.CarId == entity.CarId && r.ReturnDate == null);


            // If car is not available right now
            if(isCarAvailable != null)
                return new ErrorResult<Rental>(400,"Car is not available right now.");
            



            _rentalDal.Create(entity);
            return new SuccessResult<Rental>(201,entity);

        }

        public ICustomResult<Rental> Delete(int id)
        {
            _rentalDal.Delete( _rentalDal.Get(r => r.Id==id));
            return new SuccessResult<Rental>(204);
        }

        public ICustomResult<Rental> GetById(int id)
        {
            return new SuccessResult<Rental>(200,_rentalDal.Get(r => r.Id==id));
        }

        public ICustomResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessResult<List<Rental>>(200,_rentalDal.GetAll(filter));
        }

        public ICustomResult<Rental> Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult<Rental>(204,entity);
        }
    }
}
