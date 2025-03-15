using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMVC.Attributes
{
    public class RequireRoleAttribute : RequireLoginAttribute
    {
        private string _role;
        public RequireRoleAttribute(string role) 
        {
            _role = role;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? role = context.HttpContext.Session.GetString("Role");
            if (role == null || role != _role)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
