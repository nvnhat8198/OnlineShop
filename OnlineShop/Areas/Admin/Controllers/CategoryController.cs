using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.FE;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index()
        {
            var model = new MenuDao().listProductCategory();
            return View(model);
        }
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDao();
                menu.Link = "/TypeProduct/Index";
                menu.DisplayOrder = 3;
                menu.Status = true;
                menu.Target = "_self";
                menu.TypeID = 11;
               
                bool check = dao.InsertCategoryProduct(menu);
                if (check)
                {
                    SetAlert("Thêm mới thành công!", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công!");
                }
            }
            return View("Index");
        }

        [HttpGet]
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Edit(int id)
        {
            var dao = new MenuDao();
            var category = dao.ViewDetail(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDao();
               
                bool result = dao.Update(menu);
                if (result)
                {
                    SetAlert("Sửa thành công!", "success");
                    return RedirectToAction("Index", "Category");
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