using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ANIL\SQLEXPRESS;Database=ReCapProject;Trusted_Connection=true;TrustServerCertificate=true");

        }

        public DbSet<Car> Cars { get; set; }
    }
}
