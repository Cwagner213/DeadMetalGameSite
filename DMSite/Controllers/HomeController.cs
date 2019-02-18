using System;
using DMSite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMSite.Filters;

namespace DMSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [MyLoginFilter]
        public ActionResult Contact()
        {
            ViewBag.Message = "What do you think";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.Message = "Thanks for the feedback";
            List<EmailMember> EmailList = new List<EmailMember>();
            EmailMember member = new EmailMember();
            EmailList.Add(new EmailMember { Email = "cjwagner221@gmail.com" });
            EmailList.Add(new EmailMember { Email = "cjwagner223@gmail.com" });
            EmailList.Add(new EmailMember { Email = "cjwagner224@gmail.com" });
            EmailList.Add(new EmailMember { Email = "cjwagner225@gmail.com" });
            return View(EmailList);
        }


        public ActionResult Backstage(string secret, string format)
        {
            ViewBag.Message = "Backstage";
            if(secret != "special")
            {
                return new HttpStatusCodeResult(403);
            }

            if(format == "text")
            {
                return Content("You Rock");
            }
            else if (format == "json")
            {
                return Json(new { password = "You Rock!", expires = DateTime.UtcNow.ToShortDateString() }, JsonRequestBehavior.AllowGet);
            }
            else if (format == "clean")
            {
                return PartialView();
            }
            return View();
        }
    }
}