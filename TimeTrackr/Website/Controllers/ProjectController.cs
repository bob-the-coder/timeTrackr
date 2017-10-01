using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Cores;
using BusinessLogic.Helpers;
using BusinessLogic.Models;
using Website.Filters;

namespace Website.Controllers
{
    [AuthorizeUserCustom]
    public partial class ProjectController : BaseController
    {
        public virtual ActionResult Create()
        {
            return View(MVC.Project.Views.Create);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(Project model)
        {
            model.CreatedAt = DateTime.UtcNow;
            model.UserId = UserIdentity.Id;
            if (model.IsGitRepo)
            {
                model.Name += " [Git]";
            }

            model = await ProjectCore.CreateAsync(model, true).ConfigureAwait(false);
            if (model == null)
            {
                return RedirectToAction(MVC.Project.Actions.Create());
            }

            return RedirectToAction(MVC.Project.Actions.Details(model.Id));
        }

        public virtual async Task<ActionResult> Details(Guid id)
        {
            var navigationProperties = new[] { nameof(DataLayer.Project.Commits) };
            var project = await ProjectCore.GetAsync(id, navigationProperties).ConfigureAwait(false);
            if (project == null)
            {
                return RedirectToAction(MVC.Home.Actions.Index());
            }

            if (project.IsGitRepo)
            {
                project.Commits = await GitHubApiHelper.GetCommitsAsync(project).ConfigureAwait(false);
            }

            foreach (var commit in project.Commits)
            {
                commit.Project = null;
            }
            project.Commits = project.Commits.OrderByDescending(c => c.CreatedAt).ToList();

            return View(MVC.Project.Views.Details, project);
        }

        public virtual ActionResult GetList()
        {
            return View(MVC.Project.Views.List);
        }

        public virtual async Task<ActionResult> Statistics()
        {
            var navigationProperties = new[] { nameof(DataLayer.Project.Commits) };
            var projects = await ProjectCore.GetListAsync(p => p.UserId == UserIdentity.Id, navigationProperties).ConfigureAwait(false);

            foreach (var project in projects)
            {
                project.User = null;

                if (project.IsGitRepo)
                {
                    project.Commits = await GitHubApiHelper.GetCommitsAsync(project).ConfigureAwait(false);
                }

                foreach (var commit in project.Commits)
                {
                    commit.Project = null;
                }
            }

            return View(projects);
        }
    }
}