using System.Web.Mvc;
using Website.Filters;

namespace Website.Controllers
{
    [AuthorizeUserCustom]
    public partial class HomeController : BaseController
    {
        public virtual ActionResult Index()
        {
            ViewBag.Identity = UserIdentity;
            return View();
        }
    }
}