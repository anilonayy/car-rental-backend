using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Perfomance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        //[SecuredOperation("admin,brand.add")]
        [CacheRemoveAspect("IBrandService.Get")]
        [PerformanceAspect(5)]
        public ICustomResult<Brand> Create(Brand entity)
        {
            _brandDal.Create(entity);

            return new SuccessResult<Brand>(201, entity);
        }

        [CacheRemoveAspect("IBrandService.Get")]
        public ICustomResult<Brand> Delete(int id)
        {
            _brandDal.Delete(_brandDal.Get(b => b.BrandId==id));
            return new SuccessResult<Brand>(204);
        }

        public ICustomResult<Brand> GetById(int id)
        {
            return new SuccessResult<Brand>(200,_brandDal.Get(b => b.BrandId==id));
        }

        [CacheAspect]
        public ICustomResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return new SuccessResult<List<Brand>>(200,_brandDal.GetAll(filter));
        }

        public ICustomResult<Brand> Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult<Brand>(200,entity);
        }
    }
}
