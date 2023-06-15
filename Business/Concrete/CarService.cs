using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarService : GenericService<Car>
    {
        public CarService(IGenericDal<Car> repository) : base(repository)
        {
        }
    }
}
