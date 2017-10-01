using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Filters;

namespace Website.Controllers
{
    public partial class BaseController : Controller
    {
        public CustomIdentity UserIdentity => (CustomIdentity)User.Identity;
        // GET: Base
    }
}