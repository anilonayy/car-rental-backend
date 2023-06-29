using Core.Entities.Abstract;
using Core.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepsitoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        private readonly TContext _context;

        public void Create(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();

            }

        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {

                var data = context.Set<TEntity>().SingleOrDefault(filter);
                if (data == null)
                {
                    throw new NotFoundException($"404! {typeof(TEntity).Name} is not found..");
                }
                else
                {
                    return data;
                }
            }


        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                var data = filter != null
                ? context.Set<TEntity>().Where(filter).ToList()
                : context.Set<TEntity>().ToList();

                if (data == null)
                {
                    throw new NotFoundException($"404! {typeof(TEntity).Name} is not found..");
                }
                else
                {
                    return data;
                }
            }
        }

    }
}



