using Core.Utilities.Results;
using System.Linq.Expressions;

namespace Core.Business
{
    public interface IGenericService<TEntity> where TEntity : class, new()
    {
        IResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
        IResult<TEntity> GetById(int id);
        IResult<TEntity> Create(TEntity entity);
        IResult<TEntity> Update(TEntity entity);
        IResult<TEntity> Delete(int id);
    }
}
