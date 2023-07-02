using Core.DataAccess.EntityFramework;
using Core.Utilities.Functions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepsitoryBase<CarImage, Context>, ICarImageDal
    {
        private readonly IUriFunctions _uriFunctions;

        public EfCarImageDal(IUriFunctions uriFunctions)
        {
            _uriFunctions = uriFunctions;
        }
        public List<CarImage> GetByCar(int carId)
        {
            using (var context = new Context())
            {
                return context.CarImages.Where(c => c.CarId == carId).Select(
                c => new CarImage
                {
                    CarId = c.CarId,
                    Date = c.Date,
                    Id = c.Id,
                    ImagePath = _uriFunctions.GetHostUrl() + c.ImagePath
                }
                    ).ToList();
            }
        }
    }
}
