using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Index()
        {
            var model = new OrderDao().ListOrder();
            return View(model);
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new OrderDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}