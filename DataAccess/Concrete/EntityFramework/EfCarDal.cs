using Core.DataAccess.EntityFramework;
using Core.Entities.Abstract;
using Core.Utilities.Exceptions;
using Core.Utilities.Functions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarDTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfCarDal : EfEntityRepsitoryBase<Car, Context>, ICarDal
    {
        private readonly IUriFunctions _uriFunctions;

        public EfCarDal(IUriFunctions uriFunctions)
        {
            _uriFunctions = uriFunctions;
        }

        public List<CarDetailDto> GetWithDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (var context = new Context())
            {

                var result = context
                    .Cars
                    .Include(c => c.Brand)
                    .Include(c => c.Color)
                    .Include(c => c.CarImages)
                    .Select(c => new CarDetailDto()
                    {
                        Brand= c.Brand,
                        Color = c.Color,
                        Description = c.Description,
                        Id = c.Id,
                        ModelYear = c.ModelYear,
                        CoverImage = _uriFunctions.GetHostUrl() + (c.CarImages.Count == 0 ? "uploads/logo.png" : c.CarImages.First().ImagePath),
                        DailyPrice = c.DailyPrice
                    });

                if (filter != null)
                {
                    result = result.Where(filter);
                }

                return result.ToList();

            }
        }

        public List<CarDetailDto> GetWithDetailsByFilter(int? colorId, int? brandId)
        {

            using (var context = new Context())
            {
                var query = context.Cars
                    .Include(c => c.Brand)
                    .Include(c => c.Color)
                    .Select(c => new CarDetailDto()
                    {
                        Brand = c.Brand,
                        Color = c.Color,
                        Description = c.Description,
                        Id = c.Id,
                        ModelYear = c.ModelYear,
                        CoverImage = _uriFunctions.GetHostUrl() + (c.CarImages.Count == 0 ? "uploads/logo.png" : c.CarImages.First().ImagePath),
                        DailyPrice = c.DailyPrice
                    }).AsQueryable();

                if (colorId != 0)
                {
                   query =  query.Where(c => c.Color.ColorId == colorId);
                }
                if(brandId != 0)
                {
                    query = query.Where(c => c.Brand.BrandId == brandId);
                }

                var data =  query.ToList();


                if(data.Count == 0)
                {
                    throw new NotFoundException($"There is no car for this parameters. ");
                }
                else
                {
                    return data;
                }
            }
        }
    }

}

