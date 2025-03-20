using Eshop.Database;
using Eshop.Entities.shop;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
    public class KosikController : Controller
    {
        private DatabaseContext _context;

        public KosikController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult AddToCartAction(int id)
        {
            TempKosik koiskTemp = new TempKosik();
            // Zkontrolujeme, zda uživatel má cookie
            if (!Request.Cookies.ContainsKey("VisitorId"))
            {
                Console.WriteLine("Nemá cookies");
                // Pokud neexistuje, vytvoříme nový jedinečný identifikátor
                string uniqueId = Guid.NewGuid().ToString();
                //Console.WriteLine(uniqueId);
                // Nastavíme cookie s možnostmi
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddYears(1), // Platnost na 1 rok
                    HttpOnly = true // Cookie není přístupná skripty na straně klienta
                    //Secure = true // Pouze přes HTTPS
                };

                // Přidáme cookie do odpovědi
                Response.Cookies.Append("VisitorId", uniqueId, options);

                koiskTemp.UUID = uniqueId;


               // _context.tempKosiks.Add(koiskKUlozeni);
                //_context.SaveChanges();


                ViewBag.Message = "Nová cookie byla vytvořena: " + uniqueId;
            }
            else
            {
                Console.WriteLine("Ano, má cookies");
                koiskTemp = _context.tempKosiks.FirstOrDefault(s => s.UUID == Request.Cookies["VisitorId"]);


                // Pokud cookie existuje, načteme její hodnotu
                string existingId = Request.Cookies["VisitorId"];
                //ViewBag.Message = "Vítejte zpět! Vaše VisitorId je: " + existingId;
            }

            /*Zde doplnit Cookies*/
            Planeta p = _context.Planety.SingleOrDefault(x => x.Id == id);
            
            ////Console.ReadLine();
            //koiskKUlozeni.PlanetyVKosiku = new PlanetyVKosiku(koiskKUlozeni);
            //koiskKUlozeni.PlanetyVKosiku.UUIDTempKosiku = koiskKUlozeni.UUID;
            //koiskKUlozeni.PlanetyVKosiku.Planeta = p;
            PlanetyVKosiku planetaVKosiku = new PlanetyVKosiku(koiskTemp);
            planetaVKosiku.Planeta = p;
            //Objednavky o = new Objednavky();

            //_context.Objednavky.Add(o);
            _context.tempKosiks.Add(koiskTemp);
            _context.SaveChanges();

            _context.PlanetyVKosikus.Add(planetaVKosiku);
            _context.SaveChanges();

            //_context.
            return View();
        }
    }
}
