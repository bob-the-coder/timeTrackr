using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogic.Cores;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Website.Models;

namespace Website.Controllers
{
    public partial class AccountController : Controller
    {
        public virtual ActionResult Create()
        {
            return View(MVC.Account.Views.Register);
        }

        public virtual ActionResult Login()
        {
            return View(MVC.Account.Views.Login);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Login(UserLoginModel model)
        {
            var user = await UserCore.GetByEmailAndPasswordAsync(model.Email, model.Password).ConfigureAwait(false);
            if (user == null)
            {
                return Json(null);
            }
            //todo generate new token

            var newToken = Guid.Empty;
            HttpContext.Request.Cookies.Clear(); // clear all cookies, to start a fresh session

            var tkt = new FormsAuthenticationTicket(1, model.Email, DateTime.Now,
                DateTime.Now.AddMinutes(999), false, $"{newToken}", FormsAuthentication.FormsCookiePath);

            var cookiestr = FormsAuthentication.Encrypt(tkt);
            var ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr)
            {
                Expires = tkt.Expiration,
                Path = FormsAuthentication.FormsCookiePath
            };
            Response.Cookies.Add(ck);

            return Json("ok");
        }
    }
}