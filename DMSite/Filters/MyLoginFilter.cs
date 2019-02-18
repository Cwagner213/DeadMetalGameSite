using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMSite.Filters
{
    public class MyLoginFilter : ActionFilterAttribute 
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var req = filterContext.HttpContext.Request;

            //TODO : add custom logic

            base.OnActionExecuted(filterContext);
        }
        
    }
}