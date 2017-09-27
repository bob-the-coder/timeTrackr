using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public partial class ProjectController : Controller
    {
        // GET: Project
        public virtual ActionResult GetList()
        {
            return View(MVC.Project.Views.List);
        }
    }
}