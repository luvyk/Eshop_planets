using Microsoft.EntityFrameworkCore;
using Eshop.Entities;
using Eshop.Entities.shop;

namespace Eshop.Database
{
    public class DatabaseContext : DbContext
    {
        //public DbSet<Car> Cars { get; set; }
        //public DbSet<Account> Accounts { get; set; }
        public DbSet<Planeta> Planety { get; set; }
        public DbSet<Kategorie> Kategories { get; set; }
        public DbSet<Kosik> Kosiky { get; set; }
        public DbSet<Objednavky> Objednavky { get; set; }
        public DbSet<PlanetyKategorie> PlanetyKategories { get; set; }
        public DbSet<PlanetyVKosiku> PlanetyVKosikus { get; set; }
        public DbSet<Recenze> Recenzes { get; set; }
        public DbSet<TempKosik> tempKosiks { get; set; }
        public DbSet<Ucet> Ucty {  get; set; }

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
