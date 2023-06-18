using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepsitoryBase<Car, Context>, ICarDal
    {
        public List<CarDetailDto> GetWithDetails()
        {
            using (var context = new Context())
            {
                var results = from cars in context.Cars

                              join colors in context.Colors
                              on cars.ColorId equals colors.ColorId

                              join brands in context.Brands
                              on cars.BrandId equals brands.BrandId

                              select new CarDetailDto
                              {
                                  BrandName = brands.Name,
                                  CarName = cars.Description,
                                  ColorName = colors.Name
                              };

                return results.ToList();

            }
        }
    }
}
