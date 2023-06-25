using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CustomerDTOs;
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

        public ICustomResult<Customer> Create(Customer entity)
        {
            _customerDal.Create(entity);

            return new SuccessResult<Customer>(201,entity);
        }

        public ICustomResult<Customer> Delete(int id)
        {
            _customerDal.Delete( _customerDal.Get(c => c.Id==id));
            return new SuccessResult<Customer>(204);
        }

        public ICustomResult<Customer> GetById(int id )
        {
            return new SuccessResult<Customer>(200,_customerDal.Get(c => c.Id==id));
        }

        public ICustomResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return new SuccessResult<List<Customer>>(200,_customerDal.GetAll(filter));
        }

        public ICustomResult<Customer> Update(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult<Customer>(200,entity);
        }

        public ICustomResult<List<CustomerDetailDto>> GetCustomersWithDetail()
        {
            return new SuccessResult<List<CustomerDetailDto>>(200, _customerDal.GetCustomersWithDetail());
        }
    }
}
