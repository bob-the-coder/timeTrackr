using System.Web.Mvc;
using Website.Filters;

namespace Website.Controllers
{
    [AuthorizeUserCustom]
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}