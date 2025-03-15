using Microsoft.AspNetCore.Mvc;
using Eshop.Database;
using Eshop.Entities;
using Eshop.Helpers;
using Eshop.Models.Auth;

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

            Account? account = _context.Accounts.SingleOrDefault(a => a.Username == loginViewModel.Username);
            if (account == null || account.Password != SHA256Helper.HashPassword(loginViewModel.Password))
            {
                TempData["Message"] = "Wrong username or password!";
                TempData["MessageType"] = "danger";
                return View(loginViewModel);
            }

            HttpContext.Session.SetString("User", account.Username);
            HttpContext.Session.SetString("Role", account.Role);

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
