using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGenericDal<T> : IGenericDal<T> where T : class, IEntity, new()
    {
        private readonly Context _context;
        private readonly DbSet<T> _dbSet;

        public EfGenericDal()
        {
            _context = new Context();
            _dbSet = _context.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            return _dbSet.SingleOrDefault(filter);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter != null
                ? _dbSet.Where(filter).ToList()
                : _dbSet.ToList();
        }
    }
}
