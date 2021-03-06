﻿using Models.Dao;
using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class OrderDetailController : BaseController
    {
        // GET: Admin/OrderDetail
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Index(long id)
        {
            var model = new OrderDao().ListOrderDetail(id);
            ViewBag.OrderID = id;
            return View(model);
        }
    }
}