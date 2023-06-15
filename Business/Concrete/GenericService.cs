using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class GenericService<T> : IGenericService<T>  where T:class,IEntity,new()
    {
        private readonly IGenericDal<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IGenericDal<T> repository)
        {
            _repository = repository;
           
        }

        public void Create(T entity)
        {
            _repository.Create(entity);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _repository.Get(filter);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return _repository.GetAll(filter);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
