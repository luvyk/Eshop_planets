using Eshop.Database;
using Eshop.Entities.shop;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Eshop.Controllers
{
    public class KosikController : SecuredController
    {
        private DatabaseContext _context;

        public KosikController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult AddToCartAction(int id)
        {
            string uzJmeno = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(uzJmeno) )
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
                    //ViewBag.Message = "Nová cookie byla vytvořena: " + uniqueId;

                    _context.tempKosiks.Add(koiskTemp);
                    _context.SaveChanges();
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
                //planetaVKosiku.Planeta = p;
                planetaVKosiku.IdPlanety = p.Id;
                //Objednavky o = new Objednavky();

                //_context.Objednavky.Add(o);

                _context.PlanetyVKosikus.Add(planetaVKosiku);
                _context.SaveChanges();
            }
            else
            {
                Ucet u = _context.Ucty.FirstOrDefault(s => s.UzivatelskeJmeno == uzJmeno);
                Kosik k = _context.Kosiky.FirstOrDefault(x => x.IdUctet == u.Id);

                if (k == null)
                {
                    Kosik kosik = new Kosik();
                    kosik.IdUctet = u.Id;
                }

            }

            

            //_context.
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            int soucetCen = 0;

            if (HttpContext.Session.GetString("User") !="")
            {
                string x = Request.Cookies["VisitorId"];
                TempKosik tKos = _context.tempKosiks.FirstOrDefault(s => s.UUID == x);

                List<PlanetyVKosiku> pVK = _context.PlanetyVKosikus.Where(s => s.UUIDTempKosiku == tKos.UUID).ToList();
                List<Planeta> objednanePlanety = new List<Planeta>();
                foreach(PlanetyVKosiku v in pVK)
                {
                    objednanePlanety.Add(_context.Planety.SingleOrDefault(s => s.Id == v.IdPlanety));
                }
                foreach(Planeta kSouctu in objednanePlanety)
                {
                    soucetCen += kSouctu.Cena;
                }
                ViewBag.Soucet = soucetCen;
                ViewBag.GUID = tKos.UUID;
                ViewBag.IdKos = 0;

                return View(objednanePlanety);
            } else
            {
                string x = HttpContext.Session.GetString("User");
                Ucet u = _context.Ucty.SingleOrDefault(s => s.UzivatelskeJmeno == x);
                Kosik Kos = _context.Kosiky.FirstOrDefault(s => s.IdUctet == u.Id);

                List<PlanetyVKosiku> pVK = _context.PlanetyVKosikus.Where(s => s.IdKosiky == Kos.Id).ToList();
                List<Planeta> objednanePlanety = new List<Planeta>();
                foreach (PlanetyVKosiku v in pVK)
                {
                    objednanePlanety.Add(_context.Planety.SingleOrDefault(s => s.Id == v.IdPlanety));
                }
                foreach (Planeta kSouctu in objednanePlanety)
                {
                    soucetCen += kSouctu.Cena;
                }

                ViewBag.Soucet = soucetCen;
                ViewBag.GUID = "";
                ViewBag.IdKos = Kos.Id;

                return View(objednanePlanety);
            }
        }
        public IActionResult Obednavka(string IdKos, string GUID)
        {
            ViewBag.GUID = GUID;
            ViewBag.IdKos = IdKos;
            return View();
        }
        public IActionResult DokonciObednavku(ObednavkaModel m)
        {
            Objednavky objednavky = new Objednavky();
            objednavky.Id = m.Id;
            objednavky.Jmeno = m.Jmeno;
            objednavky.Prijmeni = m.Prijmeni;
            objednavky.SlunecniSoustava = m.SlunecniSoustava;
            objednavky.Planeta = m.Planeta;
            objednavky.Mesto = m.Mesto;
            objednavky.Ulice = m.Ulice;
            objednavky.CisloDomu = m.CisloDomu;
            objednavky.PSC = m.PSC;
            objednavky.SoustavaDoruceni = m.SoustavaDoruceni;
            objednavky.ZpusobPlatba = m.ZpusobPlatby;


            _context.Add(objednavky);
            _context.SaveChanges();

            Objednavky newIdObednavka = _context.Objednavky.FirstOrDefault( o => o.Jmeno == m.Jmeno );
            if (m.GUID != "")
            {
                TempKosik k = new TempKosik();

                k.IdObjednavky = newIdObednavka.Id;
                k.UUID = m.GUID;
                _context.tempKosiks.Update(k);
                _context.SaveChanges();
            }
            else
            {
                Kosik k = _context.Kosiky.FirstOrDefault(s => s.Id == Int32.Parse(m.IdKos));
                k.IdObjednavky = newIdObednavka.Id;
                _context.Kosiky.Update(k);
                _context.SaveChanges();
            }


            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteOrder(int id, string IdKos, string GUID)
        {
            Console.WriteLine(id);
            Console.WriteLine(IdKos);
            Console.WriteLine(GUID);
            //Console.ReadLine();
            PlanetyVKosiku naSmazani =  _context.PlanetyVKosikus.Where(s => s.IdPlanety == id).Where(q => q.IdKosiky == Int32.Parse(IdKos)).FirstOrDefault(w => w.UUIDTempKosiku == GUID);
            _context.PlanetyVKosikus.Remove(naSmazani);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
