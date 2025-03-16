using Eshop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web;

namespace Eshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Zkontrolujeme, zda uživatel má cookie
            if (!Request.Cookies.ContainsKey("VisitorId"))
            {
                // Pokud neexistuje, vytvoøíme nový jedineèný identifikátor
                string uniqueId = Guid.NewGuid().ToString();
                Console.WriteLine(uniqueId);
                // Nastavíme cookie s možnostmi
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddYears(1), // Platnost na 1 rok
                    HttpOnly = true, // Cookie není pøístupná skripty na stranì klienta
                    Secure = true // Pouze pøes HTTPS
                };

                // Pøidáme cookie do odpovìdi
                Response.Cookies.Append("VisitorId", uniqueId, options);

                ViewBag.Message = "Nová cookie byla vytvoøena: " + uniqueId;
            }
            else
            {
                // Pokud cookie existuje, naèteme její hodnotu
                string existingId = Request.Cookies["VisitorId"];
                ViewBag.Message = "Vítejte zpìt! Vaše VisitorId je: " + existingId;
            }


            return View();
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
