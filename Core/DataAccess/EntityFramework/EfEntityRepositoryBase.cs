using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepsitoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext , new()
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;

        
        public EfEntityRepsitoryBase()
        {
            using(TContext context = new TContext())
            {
                _dbSet = context.Set<TEntity>();
            }
        }

        public void Create(TEntity entity)
        {
            using(var context = new TContext())
            {
                _dbSet.Add(entity);
                context.SaveChanges();

            }

        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                _dbSet.Remove(entity);
                context.SaveChanges();

            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                _dbSet.Update(entity);
                context.SaveChanges();

            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
                return _dbSet.SingleOrDefault(filter);
           
        }

        public List<TEntity> GetAll(Expression<Func<TEntity,bool>> filter = null)
        {
            return filter != null
                ? _dbSet.Where(filter).ToList()
                : _dbSet.ToList();
        }
    }

}

