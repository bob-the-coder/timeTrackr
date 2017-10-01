using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Cores;
using BusinessLogic.Models;
using BusinessLogic.Models.Git;
using Newtonsoft.Json;

namespace Website.Controllers
{
    public partial class CommitController : BaseController
    {
        public virtual ActionResult Create(Guid id)
        {
            var viewModel = new Commit
            {
                ProjectId = id
            };
            return View(viewModel);
        }

        [HttpPost]
        public virtual async Task<JsonResult> Create(Commit model)
        {
            model.CreatedAt = DateTime.UtcNow;
            model = await CommitCore.CreateAsync(model, true).ConfigureAwait(false);

            return Json(model);
        }
    }
}