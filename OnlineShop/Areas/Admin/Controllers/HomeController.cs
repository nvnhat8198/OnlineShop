using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        //[HasCredential(RoleID = "VIEW_USER")] // Kiểm tra quyền Admin trước
        public ActionResult Index()
        {
            return View();
        }
    }
}