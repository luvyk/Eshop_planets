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
            // Zkontrolujeme, zda u�ivatel m� cookie
            if (!Request.Cookies.ContainsKey("VisitorId"))
            {
                // Pokud neexistuje, vytvo��me nov� jedine�n� identifik�tor
                string uniqueId = Guid.NewGuid().ToString();
                Console.WriteLine(uniqueId);
                // Nastav�me cookie s mo�nostmi
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddYears(1), // Platnost na 1 rok
                    HttpOnly = true, // Cookie nen� p��stupn� skripty na stran� klienta
                    Secure = true // Pouze p�es HTTPS
                };

                // P�id�me cookie do odpov�di
                Response.Cookies.Append("VisitorId", uniqueId, options);

                ViewBag.Message = "Nov� cookie byla vytvo�ena: " + uniqueId;
            }
            else
            {
                // Pokud cookie existuje, na�teme jej� hodnotu
                string existingId = Request.Cookies["VisitorId"];
                ViewBag.Message = "V�tejte zp�t! Va�e VisitorId je: " + existingId;
            }

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
