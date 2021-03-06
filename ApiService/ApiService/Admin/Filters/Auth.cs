using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Repository.Services;

namespace Admin.Filters
{
    public class Auth : ActionFilterAttribute
    {
        private readonly IAdminService _adminService;
        public Auth(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Cookies.TryGetValue("admin-token", out string token))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "login", controller = "account" }));
            }

            var admin = _adminService.CheckByToken(token);

            if (admin == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "login", controller = "account" }));
            }

            var controller = context.Controller as Controller;
            if (controller != null)
            {
                controller.ViewBag.Admin = admin;
            }

            context.RouteData.Values["Admin"] = admin;
        }
    }
}
