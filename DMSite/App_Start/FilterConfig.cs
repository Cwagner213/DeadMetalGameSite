using System.Web;
using System.Web.Mvc;
using DMSite.Filters;

namespace DMSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyLoginFilter());
        }
    }
}
