using Business.Abstract;
using Core.Aspects.Autofac.Perfomance;
using Core.Utilities.Business;
using Core.Utilities.Exceptions;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly ICarService _carService;

        public BrandManager(IBrandDal brandDal, ICarService carService)
        {
            _brandDal = brandDal;
            _carService = carService;
        }

        [PerformanceAspect(5)]
        public IResult<Brand> Create(Brand entity)
        {
            _brandDal.Create(entity);

            return new CreatedResult<Brand>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, entity);
        }

        public IResult<Brand> Delete(int id)
        {

            var result = BusinessRules.Run(
                    BrandHasAnyCar(id)
            );

            if (result != null)
                return result;


            _brandDal.Delete(_brandDal.Get(b => b.BrandId == id));
            return new NoContentResult<Brand>();
        }

        public IResult<Brand> GetById(int id)
        {
            return new SuccessResult<Brand>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, _brandDal.Get(b => b.BrandId == id));
        }

        public IResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return new SuccessResult<List<Brand>>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, _brandDal.GetAll(filter));
        }

        public IResult<Brand> Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult<Brand>(OperationMessages.SuccessTitle, OperationMessages.SuccessMessage, entity);
        }


        private IResult<Brand> BrandHasAnyCar(int brandId)
        {
            var car = _carService.GetByColorAndBrand(0,brandId);

            if (car.data.Count == 0)
            {
                return new NoContentResult<Brand>();
            }
            else
            {
                throw new ConflictException("There is a car of this brand. Please remove the dependencies.");
            }
        }
    }
}

