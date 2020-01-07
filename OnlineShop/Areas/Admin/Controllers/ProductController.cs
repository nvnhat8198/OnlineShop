using Models.Dao;
using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index()
        {
            var model = new ProductDao().getAllProduct();
            return View(model);
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        [HttpPost]
        public JsonResult Delete(long id)
        {
            //new ProductDao().Delete(id);
            return Json(new
            {
                Status = true
            });
        }

        [HttpPost]
        public JsonResult ListProductCategory()
        {
            var data = new ProductDao().ListProductCategory();
            return Json(new
            {
                data = data,
                Status = true
            });
        }

        [HttpGet]
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            var product = new Product();
            product.Name = model.Name;
            product.Description = model.Description;
            product.Image = model.Image;
            product.Price = model.Price;
            product.PromotionPrice = model.PromotionPrice;
            product.CategoryID = model.CategoryID;
            product.Status = true;
            product.CreatedDate = DateTime.Now;
            product.MetaTittle = "/san-pham";

            new ProductDao().InsertProduct(product);
            return Redirect("/Admin/Product/Index");
        }

        [HttpGet]
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Edit(long id)
        {
            var model = new ProductDao().DetailProduct(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                
                
                bool result = dao.Update(product);
                if (result)
                {
                    SetAlert("Sửa User thành công!", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công!");
                }
            }
            return View("Index");
        }
    }
}