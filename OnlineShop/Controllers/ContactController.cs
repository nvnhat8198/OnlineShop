using Models.Dao;
using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var listMenu = new MenuDao().ListMenu();
            return View(listMenu);
        }

        [HttpPost]
        public ActionResult PostInfo(string name, string email, string phone, string content)
        {
            var feekback = new Feedback();
            feekback.Name = name;
            feekback.Email = email;
            feekback.Phone = phone;
            feekback.Content = content;
            feekback.CreateDate = DateTime.Now;
            feekback.Status = true;

            new FeedbackDao().AddFeedback(feekback);
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult PostEmail(string email)
        {
            var feekback = new Feedback();
            feekback.Email = email;
            feekback.CreateDate = DateTime.Now;
            feekback.Status = true;
            new FeedbackDao().AddFeedback(feekback);
            return Redirect("/");
        }
    }
}