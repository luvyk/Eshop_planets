using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Eshop.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.IsAuthenticated = context.HttpContext.Session.GetString("User") != null;
            ViewBag.Username = context.HttpContext.Session.GetString("User");
            ViewBag.Role = context.HttpContext.Session.GetString("Role");
            base.OnActionExecuting(context);
        }
    }
}
