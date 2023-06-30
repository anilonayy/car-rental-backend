using Core.DataAccess.EntityFramework;
using Core.Utilities.Functions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarDTOs;
using Entities.DTOs.RentalDTOs;
using Entities.DTOs.UserDTOs;
using Microsoft.EntityFrameworkCore;

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
                                 Car = new CarDetailDto
                                 {
                                     Id = cars.Id,
                                     Brand = brands,
                                     Color= colors
                                   
                                 },
                                 User = new UserDetailDto {
                                    FirstName = users.FirstName,
                                    LastName = users.LastName
                                 },
                                 PlannedReturnDate = ((DateTime)rentals.ReturnDate).ToShortDateString(),
                                 RentDate = ((DateTime)rentals.RentDate).ToShortDateString()
                             });

                return result.ToList();
            }
        }

        public Rental GetRentalWithDetail(int rentalId)
        {
            using(var context = new Context())
            {
               return context.Rentals
                    .Include(r => r.Car)
                    .Include(r => r.Car.Brand)
                    .Include(r => r.Car.Color)
                    .Single(r => r.Id == rentalId);
            }
        }
    }
}
