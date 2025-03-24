using Microsoft.AspNetCore.Mvc;
using Eshop.Database;
using Eshop.Entities;
using Eshop.Helpers;
using Eshop.Models.Auth;
using Eshop.Entities.shop;

namespace Eshop.Controllers
{
    public class AuthController : BaseController
    {
        private DatabaseContext _context;

        public AuthController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            Ucet? account = _context.Ucty.SingleOrDefault(a => a.UzivatelskeJmeno == loginViewModel.Username);
            if (account == null || account.Heslo != SHA256Helper.HashPassword(loginViewModel.Password))
            {
                TempData["Message"] = "Wrong username or password!";
                TempData["MessageType"] = "danger";
                return View(loginViewModel);
            }

            HttpContext.Session.SetString("User", account.UzivatelskeJmeno);
            HttpContext.Session.SetString("Role", account.Role);


            Ucet u = _context.Ucty.FirstOrDefault(x => x.UzivatelskeJmeno == account.UzivatelskeJmeno);
            if (u == null)
            {
                Ucet ucet = new Ucet();
                ucet.UzivatelskeJmeno = account.UzivatelskeJmeno;
                ucet.Role = account.Role;
                ucet.Heslo = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92";

                _context.Ucty.Add(ucet); 
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            HttpContext.Session.Remove("Role");

            return RedirectToAction("Index", "Home");
        }
    }
}
