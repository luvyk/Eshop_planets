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

        public IActionResult Index(string kategorie)
        {
            Console.WriteLine(kategorie);
            List<Planeta> planety = new List<Planeta>();
            if (kategorie == null)
            {
                planety = _context.Planety.Where(s => s.PocetNaSklade > 0).ToList();
            }
            else if(kategorie != "nejdrazsi" && kategorie != "odNejevnejsi")
            {
                Kategorie kat = _context.Kategories.FirstOrDefault(s => s.Nazev == kategorie);
                List<PlanetyKategorie> planetyKategorie = _context.PlanetyKategories.Where(s => s.KategorieId == kat.Id).ToList();

                List<Planeta> pp = new List<Planeta>();
                foreach(PlanetyKategorie k in  planetyKategorie)
                {
                    pp = _context.Planety.Where(s => s.PocetNaSklade > 0).Where(c => c.Id == k.PlanetyId).ToList();
                }
                planety.AddRange(pp);
            }
            
            
            //List<Planeta> test = new List<Planeta>();
            //test = _context.Planety.ToList();
            foreach (Planeta planeta in planety)
            {
                Console.WriteLine(planeta.Nazev);
            }
            
            List<Kategorie> list = _context.Kategories.ToList();
            /*
            if (kategorie == "nejdrazsi")
            {
                planety = planety.OrderBy(s => s.Cena).ToList();
            }
            else if (kategorie == "odNejevnejsi")
            {
                planety = planety.OrderByDescending(s => s.Cena).ToList();
            }
            */
            var tuple = (planety, list);

            return View(tuple);
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

        public IActionResult Detail(int id)
        {
            List<Planeta> p = new List<Planeta> { _context.Planety.FirstOrDefault(s => s.Id == id) };
            //Console.WriteLine(p.Nazev);
            //Console.ReadLine();
            return View(p);
        }

    }
}
