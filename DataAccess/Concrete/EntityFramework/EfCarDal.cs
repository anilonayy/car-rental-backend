using Core.DataAccess.EntityFramework;
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

        public List<CarDetailDto> GetWithDetails(Expression<Func<CarDetailDto,bool>> filter = null)
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
                        BrandId = c.BrandId,
                        ColorId = c.ColorId,
                        BrandName = c.Brand.Name,
                        CarName = c.Description,
                        ColorName = c.Color.Name,
                        Id = c.Id,
                        ModelYear = c.ModelYear,
                        CoverImg = _uriFunctions.GetHostUrl()  + (c.CarImages.Count == 0 ? "uploads/logo.png" : c.CarImages.First().ImagePath),
                        DailyPrice = c.DailyPrice
                    });

                if(filter!=null)
                {
                    result = result.Where(filter);
                }

                return result.ToList();

            }
        }

        
    }
    
}

