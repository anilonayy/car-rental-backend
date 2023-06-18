using Core.Utilities.Results.Abstract;
using System.Linq.Expressions;

namespace Core.Business
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
        IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
