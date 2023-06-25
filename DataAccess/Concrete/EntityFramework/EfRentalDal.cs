using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarDTOs;
using Entities.DTOs.RentalDTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepsitoryBase<Rental, Context>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsWithDetail()
        {
            using(var context = new Context())
            {
                var result = (from rentals in context.Rentals

                             join cars in context.Cars
                             on rentals.CarId equals cars.Id

                             join colors in context.Colors
                             on cars.ColorId equals colors.ColorId

                             join brands in context.Brands
                             on cars.BrandId equals brands.BrandId

                             join customers in context.Customers
                             on rentals.CustomerId equals customers.Id

                             join users in context.Users
                             on customers.UserId equals users.Id


                             select new RentalDetailDto
                             {
                                 Id = rentals.Id,
                                 CarDetail = new CarDetailDto
                                 {
                                     Id = cars.Id,
                                     BrandName = brands.Name,
                                     CarName = cars.Description,
                                     ColorName = colors.Name
                                 },
                                 CustomerName = users.FirstName+" "+users.LastName,
                                 ReturnDate = ((DateTime)rentals.ReturnDate).ToShortDateString(),
                                 RentDate = rentals.RentDate.ToShortDateString()
                             });

                return result.ToList();
            }
        }
    }
}
