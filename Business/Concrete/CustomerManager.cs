using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<Customer> Create(Customer entity)
        {
            _customerDal.Create(entity);

            return new SuccessDataResult<Customer>(entity);
        }

        public IResult Delete(int id)
        {
            _customerDal.Delete( _customerDal.Get(c => c.Id==id));
            return new SuccessResult();
        }

        public IDataResult<Customer> GetById(int id )
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id==id));
        }

        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(filter));
        }

        public IResult Update(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult();
        }
    }
}
