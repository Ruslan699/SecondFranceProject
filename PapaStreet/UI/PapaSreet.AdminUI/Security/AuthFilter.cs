using System.Web.Mvc;
using System.Web.Routing;
using FilterAttribute = System.Web.Mvc.FilterAttribute;
using IActionFilter = System.Web.Mvc.IActionFilter;

namespace PapaSreet.AdminUI.Security
{
    public class AuthFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool skipAuthorization =
                filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            if (skipAuthorization) return;

            if (!CustomIdentity.IsAuthenticated)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 403;
                    filterContext.Result = new JsonResult
                    {
                        Data = new { Error = "Access denied", },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                    filterContext.Result = new RedirectResult("/Error/AccessDenied");

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Admin" },
                    { "action", "Login" }
                });
            }
        }
    }
}