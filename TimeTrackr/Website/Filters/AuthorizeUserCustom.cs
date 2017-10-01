using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Filters
{
    public class AuthorizeUserCustom : AuthorizeAttribute
    {
        public AuthorizeUserCustom()
        {
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated || !(filterContext.HttpContext.User is CustomPrincipal) ||
                !(filterContext.HttpContext.User.Identity is CustomIdentity))
            {
                var request = filterContext.HttpContext.Request;
                filterContext.HttpContext.Response.StatusCode = 401;

                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                AuthorizeUser(filterContext);
            }
        }

        protected void AuthorizeUser(AuthorizationContext filterContext)
        {
            try
            {
                if (filterContext.HttpContext.User.Identity is CustomIdentity == false && filterContext.HttpContext.User is CustomPrincipal == false)
                {

                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.Result = new HttpUnauthorizedResult();
                    return;
                }

                var principal = filterContext.HttpContext.User as CustomPrincipal;
                var identity = filterContext.HttpContext.User.Identity as CustomIdentity;

                if (principal != null && identity != null)
                {
                    return;
                }

                filterContext.HttpContext.Response.StatusCode = 401;
                filterContext.Result = new HttpUnauthorizedResult();
            }
            catch (Exception ex)
            {
                filterContext.HttpContext.Response.StatusCode = 401;
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }

}