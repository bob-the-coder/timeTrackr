using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogic.Cores;
using BusinessLogic.ModelCore;
using BusinessLogic.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Website.Filters;
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
        public virtual async Task<ActionResult> Create(UserRegisterModel model)
        {
            if (!ModelState.IsValid || !model.Password.Equals(model.ConfirmPassword, StringComparison.Ordinal))
            {
                return new HttpNotFoundResult();
            }

            var userModel = new User
            {
                Email = model.Email,
                Password = BusinessLogic.Util.PasswordHasher.GetPasswordHash(model.Password)
            };

            userModel = await UserCore.CreateAsync(userModel, true).ConfigureAwait(false);

            if (userModel == null)
            {
                return new HttpNotFoundResult();
            }

            return View(MVC.Account.Views.Login);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Login(UserLoginModel model)
        {
            var user = await UserCore.GetByEmailAndPasswordAsync(model.Email, model.Password).ConfigureAwait(false);
            if (user == null)
            {
                return RedirectToAction(MVC.Account.Actions.Login());
            }

            var token = await AuthTokenCore.CreateAsync(new AuthToken {UserId = user.Id}).ConfigureAwait(false);

            HttpContext.Request.Cookies.Clear(); // clear all cookies, to start a fresh session

            var tkt = new FormsAuthenticationTicket(1, model.Email, DateTime.Now,
                DateTime.Now.AddMinutes(999), false, $"{token.Id}#{Guid.NewGuid()}#{token.Id}", FormsAuthentication.FormsCookiePath);

            var cookiestr = FormsAuthentication.Encrypt(tkt);
            var ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr)
            {
                Expires = tkt.Expiration,
                Path = FormsAuthentication.FormsCookiePath
            };
            Response.Cookies.Add(ck);

            return RedirectToAction(MVC.Home.Actions.Index());
        }

        [AuthorizeUserCustom]
        public ActionResult LogOut()
        {
            HttpContext.Request.Cookies.Clear();
            FormsAuthentication.SignOut();

            return RedirectToAction(MVC.Account.Actions.Login());
        }
    }
}