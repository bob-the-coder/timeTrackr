using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Website.Models;

namespace Website.Controllers
{
    [Authorize]
    public partial class AccountController : Controller
    {
        public virtual ActionResult Create()
        {
            return View(MVC.Account.Views.Register);
        }
    }
}