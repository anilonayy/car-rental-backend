using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork()
        {
            _context = new Context();   
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
