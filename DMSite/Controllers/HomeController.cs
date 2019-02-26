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
          
            UsersEntities3 db = new UsersEntities3();

            UserTable person = db.UserTables.SingleOrDefault(x => x.ID == 1);

            EmailMember MemberToView = new EmailMember();

            MemberToView.ID = person.ID;
            MemberToView.Email = person.Email;

            return View(MemberToView);
        }

 
        public ActionResult ContactSubmit(EmailMember member)
        {

            try
            {

                UsersEntities3 db = new UsersEntities3();

                UserTable newMember = new UserTable();
                newMember.Email = member.Email;

                db.UserTables.Add(newMember);
                db.SaveChanges();

                int latestID = newMember.ID;

               
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Contact");
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