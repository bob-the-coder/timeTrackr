using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogic.Cores;
using BusinessLogic.ModelCore;
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
                var validationTokenCopy = new Guid(data[2]);
                
                if (validationToken == Guid.Empty || validationToken != validationTokenCopy)
                {
                    // invalid token
                    return;
                }

                SetCustomPrincipal(filterContext, validationToken);
            }
            catch (Exception ex)
            {
                filterContext.HttpContext.Response.StatusCode = 401;
            }
        }

        #region private methods

        private static void SignOutAndSetStatusCode(AuthorizationContext filterContext)
        {
            FormsAuthentication.SignOut();
            filterContext.HttpContext.Response.StatusCode = 401;
        }

        private static void SetCustomPrincipal(AuthorizationContext filterContext, Guid validationToken)
        {
            if (validationToken == Guid.Empty)
            {
                SignOutAndSetStatusCode(filterContext);
                return;
            }

            var authToken = Task.Run(async () => await AuthTokenCore.GetAsync(validationToken).ConfigureAwait(false)).GetAwaiter().GetResult();
            if (authToken == null)
            {
                SignOutAndSetStatusCode(filterContext);
                return;
            }

            var user = Task.Run(async () => await UserCore.GetAsync(authToken.UserId).ConfigureAwait(false)).GetAwaiter().GetResult();
            if (user == null)
            {
                SignOutAndSetStatusCode(filterContext);
                return;
            }

            var identity = new CustomIdentity(user);

            var newUser = new CustomPrincipal(identity);

            //set the custom principal
            filterContext.HttpContext.User = newUser;
        }

        #endregion
    }
}