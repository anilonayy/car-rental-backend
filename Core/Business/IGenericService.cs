using Core.Utilities.Results;
using System.Linq.Expressions;

namespace Core.Business
{
    public interface IGenericService<TEntity> where TEntity : class,new()
    {
        ICustomResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
        ICustomResult<TEntity> GetById(int id);
        ICustomResult<TEntity> Create(TEntity entity);
        ICustomResult<TEntity> Update(TEntity entity);
        ICustomResult<TEntity> Delete(int id);
    }
}
