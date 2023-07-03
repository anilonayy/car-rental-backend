using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CustomerDTOs;

namespace Business.Abstract
{
    public interface ICustomerService : IGenericService<Customer>
    {
        IResult<List<CustomerDetailDto>> GetCustomersWithDetail();
    }
}
