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
            /*Zde doplnit Cookies*/
            Planeta p = _context.Planety.SingleOrDefault(x => x.Id == id);
            //_context.
            return View();
        }
    }
}
