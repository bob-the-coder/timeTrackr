using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogic.Models;

namespace Website.Filters
{
    public class GlobalIdentityInjectorAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                var authCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return;
                }
                //Extract the forms authentication cookie
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket == null)
                {
                    return;
                }
                var concatenatedUserData = authTicket.UserData;
                var data = concatenatedUserData.Split(new[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                if (data.Count() != 3)
                {
                    return;
                }

                var validationToken = new Guid(data[0]);
                
                if (validationToken == Guid.Empty)
                {
                    // invalid token
                    return;
                }

                var middlewareAccessToken = data[2];
                SetCustomPrincipal(filterContext, validationToken);
            }
            catch (Exception ex)
            {
                filterContext.HttpContext.Response.StatusCode = 401;
            }
        }

        #region private methods


        private static void SetCustomPrincipal(AuthorizationContext filterContext, Guid validationToken)
        {
            if (validationToken == Guid.Empty)
            {
                FormsAuthentication.SignOut();
                filterContext.HttpContext.Response.StatusCode = 401;
                return;
            }

            //todo get user by token
            //todo FormsAuthentication.SignOut() and return 401 if no user is found
            var identity = new CustomIdentity(new User());

            var newUser = new CustomPrincipal(identity);

            //set the custom principal
            filterContext.HttpContext.User = newUser;
        }

        #endregion
    }
}