using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System.Linq.Expressions;

namespace Core.Business
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
        IDataResult<TEntity> GetById(int id);
        IDataResult<TEntity> Create(TEntity entity);
        IResult Update(TEntity entity);
        IResult Delete(TEntity entity);
    }
}
