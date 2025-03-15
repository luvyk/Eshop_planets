using Microsoft.EntityFrameworkCore;
using Eshop.Entities;

namespace Eshop.Database
{
    public class DatabaseContext : DbContext
    {
        //public DbSet<Car> Cars { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public DatabaseContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            //optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=zikan_db1;user=zikanread;password=123456;charset=utf8;");
        }
    }
}
