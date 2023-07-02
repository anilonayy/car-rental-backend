using Business.Abstract;
using Core.Utilities.Results;
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

        public ICustomResult<Color> Create(Color entity)
        {
            _colorDal.Create(entity);

            return new SuccessResult<Color>(201, entity);
        }

        public ICustomResult<Color> Delete(int id)
        {
            _colorDal.Delete(_colorDal.Get(c => c.ColorId == id));

            return new SuccessResult<Color>(204);
        }

        public ICustomResult<Color> GetById(int id)
        {
            return new SuccessResult<Color>(200, _colorDal.Get(c => c.ColorId == id));
        }

        public ICustomResult<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return new SuccessResult<List<Color>>(200, _colorDal.GetAll(filter));
        }

        public ICustomResult<Color> Update(Color entity)
        {
            _colorDal.Update(entity);

            return new SuccessResult<Color>(200, entity);
        }
    }
}
