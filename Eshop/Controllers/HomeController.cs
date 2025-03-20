using Eshop.Database;
using Eshop.Entities.shop;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web;

namespace Eshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DatabaseContext _context;

        public HomeController(DatabaseContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {


            List<Planeta> planety = _context.Planety.Where(s =>s.PocetNaSklade > 0).ToList();
            
            //List<Planeta> test = new List<Planeta>();
            //test = _context.Planety.ToList();
            foreach (Planeta planeta in planety)
            {
                Console.WriteLine(planeta.Nazev);
            }
            

            return View(planety);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
