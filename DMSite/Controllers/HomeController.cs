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
            UsersEntities3 db = new UsersEntities3();
        
           


            return View();
        }

        public ActionResult DevBlog(int pageNum)
        {
            UsersEntities3 db = new UsersEntities3();
            List<UserTable> EmailList = db.UserTables.ToList();
            List<EmailMember> EmailMemberPass = new List<EmailMember>();

            if(EmailList[pageNum] != null)
            {

            }
            else
            {

            }

            return View();
        }

        public ActionResult DevBlogPageFlip()
        {
            return View();
        }


        public ActionResult DevBlogPost(string secret, string format)
        {
            if(secret != "CatsCats213")
            {
                return new HttpStatusCodeResult(403);
            }
            return View();
        }

        public ActionResult DevBlogSave()
        {

            
            return RedirectToAction("DevBlog");
        }

        public ActionResult About()
        {

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
            MemberToView.Email = "";

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


     
    }
}