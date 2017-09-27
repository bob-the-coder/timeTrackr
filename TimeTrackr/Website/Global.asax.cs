using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var isGet = HttpContext.Current.Request.RequestType.ToLowerInvariant().Contains("get");
            if (!isGet || HttpContext.Current.Request.Url.AbsolutePath.Contains("."))
            {
                return;
            }

            var lowercaseURL = (Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.Url.AbsolutePath);
            if (!Regex.IsMatch(lowercaseURL, @"[A-Z]"))
            {
                return;
            }

            lowercaseURL = lowercaseURL.ToLower() + HttpContext.Current.Request.Url.Query;

            Response.Clear();
            Response.Status = "301 Moved Permanently";
            Response.AddHeader("Location", lowercaseURL);
            Response.End();
        }
    }
}
