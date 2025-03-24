using Eshop.Database;
using Eshop.Entities;
using Microsoft.EntityFrameworkCore;
using Eshop.Helpers;

namespace Eshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string uniqueId = Guid.NewGuid().ToString();
            //Console.WriteLine(uniqueId);
            string test = "123456";
            Console.WriteLine(SHA256Helper.HashPassword(test));

            var builder = WebApplication.CreateBuilder(args);

            /* Entity Framework */

            string connectionString = builder.Configuration.GetConnectionString("MySQL")
                ?? throw new InvalidOperationException("MySQL connection string is not provided");

            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseMySQL(connectionString)
            );

            /* Session */

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
