using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PapaStreet.WebUI.Security
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

            if (!Identity.IsAuthenticated)
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
                {
                    filterContext.Result = new RedirectResult("/Error/AccessDenied");
                }
                filterContext.Result = new RedirectResult($"/PapaStreet/login?returnUrl={filterContext.HttpContext.Request.Url.AbsolutePath}");
            }
        }
    }
}