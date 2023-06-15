using Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IGenericDal<T> where T :class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
