using Models.Dao;
using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            setViewBag();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Category model)
        {

            if (ModelState.IsValid)
            {

            }

            setViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long ID)
        {
            var dao = new ContentDao();
            var content = dao.getByID(ID);

            setViewBag(content.CategoryID);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Content model)
        {

            if (ModelState.IsValid)
            {

            }

            setViewBag(model.CategoryID);
            return View();
        }


        public void setViewBag(long? selectedID = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.listAll(), "ID", "Name", selectedID);
        }
    }
}