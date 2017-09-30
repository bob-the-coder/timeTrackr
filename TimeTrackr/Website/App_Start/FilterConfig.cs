using System.Web;
using System.Web.Mvc;
using Website.Filters;

namespace Website
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new GlobalIdentityInjectorAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
