using System.Threading.Tasks;
using System.Web.Mvc;
using BusinessLogic.Cores;
using Website.Filters;

namespace Website.Controllers
{
    [AuthorizeUserCustom]
    public partial class HomeController : BaseController
    {
        public virtual async Task<ActionResult> Index()
        {
            var navigationProperties = new[] {nameof(DataLayer.Project.Commits)};
            var projects = await ProjectCore.GetListAsync(prj => prj.UserId == UserIdentity.Id, navigationProperties).ConfigureAwait(false);

            return View(projects);
        }
    }
}