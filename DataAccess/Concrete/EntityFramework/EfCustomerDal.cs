using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CustomerDTOs;
using Entities.DTOs.UserDTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepsitoryBase<Customer, Context>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomersWithDetail()
        {
            using (var context = new Context())
            {

                var result = (from customer in context.Customers

                              join user in context.Users
                              on customer.UserId equals user.Id

                              select new CustomerDetailDto
                              {
                                  Id = customer.Id,
                                  UserDetails = new UserDetailDto
                                  {
                                      FirstName = user.FirstName,
                                      LastName = user.LastName,
                                      Email = user.Email
                                  },
                                  CompanyName = customer.CompanyName

                              }).ToList();




                return result;

            }
        }
    }
}
