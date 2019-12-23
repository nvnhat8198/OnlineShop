using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.listProductPromotion = new ProductDao().ListProductPromotion();
            ViewBag.listProductNew = new ProductDao().ListProductNew();
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration =3600*24)]
        public ActionResult Header()
        {
            var listMenu = new MenuDao().ListMenu();
            return PartialView(listMenu);
        }
    }
}