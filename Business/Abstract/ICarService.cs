using Core.Business;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService : IGenericService<Car>
    {
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
    }
}
