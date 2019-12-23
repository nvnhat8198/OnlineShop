using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class TypeProductController : Controller
    {
        // GET: TypeProduct
        [HttpGet]
        public ActionResult Index(long id)
        {
            var model = new ProductDao().ListProduct(id);
            ViewBag.productType = new ProductDao().ProductType(id);
            return View(model);
        }
    }
}