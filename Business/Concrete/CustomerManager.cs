using Business.Abstract;
using Core.Utilities.Messages;
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

        public IResult<Customer> Create(Customer entity)
        {
            _customerDal.Create(entity);

            return new CreatedResult<Customer>(OperationMessages.SuccessMessage,OperationMessages.SuccessMessage, entity);
        }

        public IResult<Customer> Delete(int id)
        {
            _customerDal.Delete(_customerDal.Get(c => c.Id == id));
            return new NoContentResult<Customer>();
        }

        public IResult<Customer> GetById(int id)
        {
            return new SuccessResult<Customer>(OperationMessages.SuccessMessage,OperationMessages.SuccessMessage, _customerDal.Get(c => c.Id == id));
        }

        public IResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return new SuccessResult<List<Customer>>(OperationMessages.SuccessMessage,OperationMessages.SuccessMessage, _customerDal.GetAll(filter));
        }

        public IResult<Customer> Update(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult<Customer>(OperationMessages.SuccessMessage,OperationMessages.SuccessMessage, entity);
        }

        public IResult<List<CustomerDetailDto>> GetCustomersWithDetail()
        {
            return new SuccessResult<List<CustomerDetailDto>>(OperationMessages.SuccessMessage,OperationMessages.SuccessMessage, _customerDal.GetCustomersWithDetail());
        }
    }
}
