using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.CustomerDTOs;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<CustomerDetailDto> GetCustomersWithDetail();
    }
}
