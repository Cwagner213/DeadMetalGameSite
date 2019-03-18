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

        public ActionResult DevBlog()
        {
            UsersEntities db = new UsersEntities();
            List<Post> EmailList = db.Posts.ToList();
            List<PostModel> EmailPostPass = new List<PostModel>();
            if (EmailList.Count > 0)
            {
                if (EmailList[0] != null)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (EmailList[i] != null)
                        {
                            PostModel temp = new PostModel();
                            temp.Post1 = EmailList[i].Post1;
                            temp.Id = EmailList[i].Id;

                            EmailPostPass.Add(temp);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {

                }
            }
            return View(EmailPostPass);
        }

        public ActionResult DevBlogPageFlip(int pageNum)
        {
            UsersEntities db = new UsersEntities();
            List<UserTable> EmailList = db.UserTables.ToList();
            List<EmailMember> EmailMemberPass = new List<EmailMember>();

            if (EmailList[pageNum] != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (EmailList[pageNum + i] != null)
                    {
                        EmailMember temp = new EmailMember();
                        temp.Email = EmailList[pageNum + i].Email;
                        temp.ID = EmailList[pageNum + i].ID;

                        EmailMemberPass.Add(temp);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {

            }
            ViewBag.page = pageNum;
            return View(EmailMemberPass);
        }

        public ActionResult DevBlogPost(string secret, string format)
        {
            if(secret != "CatsCats213")
            {
                return new HttpStatusCodeResult(403);
            }

            return View();
        }

        public ActionResult DevBlogSave(PostModel postToAdd)
        {


            try
            {

                UsersEntities db = new UsersEntities();
                Post tempPost = new Post();

                tempPost.Post1 = postToAdd.Post1;
     
                db.Posts.Add(tempPost);
                db.SaveChanges();
           
            }
            catch (Exception ex)
            {
                throw ex;
            }

          
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

            UsersEntities db = new UsersEntities();

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

                UsersEntities db = new UsersEntities();
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