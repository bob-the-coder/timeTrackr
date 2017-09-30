using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Filters
{
    public class CheckUserAuthenticityAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var action = filterContext.ActionDescriptor;
            if (action.IsDefined(typeof(OverrideAuthorizationAttribute), true)) return;

            try
            {
                if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                    filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                {
                    return;
                }
                // Check for authorization
                if (filterContext.HttpContext.User is CustomPrincipal &&
                    filterContext.HttpContext.User.Identity is CustomIdentity)
                {
                    return;
                }
                if (!filterContext.HttpContext.Request.RawUrl.Contains("Login") &&
                    !filterContext.HttpContext.Request.RawUrl.Contains("Logout"))
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                }
            }
            catch (Exception ex)
            {
                // todo
            }
        }
    }
}