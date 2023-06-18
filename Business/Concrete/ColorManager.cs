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

        public IDataResult<Color> Create(Color entity)
        {
            _colorDal.Create(entity);

            return new SuccessDataResult<Color>(entity);
        }

        public IResult Delete(Color entity)
        {
            _colorDal.Delete(entity);

            return new SuccessResult();
        }

        public IDataResult<Color> Get(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId==id));
        }

        public IDataResult<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(filter));
        }

        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);

            return new SuccessResult();
        }
    }
}
