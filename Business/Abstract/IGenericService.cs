using Entities.Abstract;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IGenericService<T> where T : class, IEntity,new() 
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
