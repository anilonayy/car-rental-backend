using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Create(Color entity)
        {
            _colorDal.Create(entity);
        }

        public void Delete(Color entity)
        {
            _colorDal.Delete(entity);
        }

        public IDataResult<Color> Get(Expression<Func<Color, bool>> filter)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(filter));
        }

        public IDataResult<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(filter));
        }

        public void Update(Color entity)
        {
            _colorDal.Update(entity);
        }
    }
}
