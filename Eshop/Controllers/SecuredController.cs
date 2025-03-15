using Microsoft.AspNetCore.Mvc.Filters;

namespace Eshop.Controllers
{
    public class SecuredController : BaseController
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? username = context.HttpContext.Session.GetString("User");
            if (username == null)
            {
                context.Result = RedirectToAction("Login", "Auth");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
