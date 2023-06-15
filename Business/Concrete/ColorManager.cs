using Business.Abstract;
using Core.Entities;
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

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            return _colorDal.Get(filter);
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return _colorDal.GetAll(filter);
        }

        public void Update(Color entity)
        {
            _colorDal.Update(entity);
        }
    }
}
