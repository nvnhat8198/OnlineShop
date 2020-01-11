using Models.Dao;
using Models.FE;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Data.Common;
using Common;
using System.Configuration;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return View(list);
        }

        public ActionResult AddItem(long id, int quantity)
        {
            var product = new ProductDao().DetailProduct(id);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == id))
                {
                    foreach(var item in list)
                    {
                        if (item.Product.ID == id)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;

                var list = new List<CartItem>();
                list.Add(item);

                Session[CartSession] = list;
            }
            return Redirect("/gio-hang");
        }

        public ActionResult DeleteItem(long id)
        {
            var product = new ProductDao().DetailProduct(id);
            var cart = Session[CartSession];
            if(cart != null)
            {
                var list = (List<CartItem>)cart;
                foreach(var item in list)
                {
                    if (item.Product.ID == id)
                    {
                        list.Remove(item);
                        break;
                    }
                }
                Session[CartSession] = list;
            }
            return Redirect("/gio-hang");
        }

        public ActionResult UpdateAdd(long id)
        {
            var product = new ProductDao().DetailProduct(id);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                foreach (var item in list)
                {
                    if (item.Product.ID == id)
                    {
                        item.Quantity += 1;   
                    }
                }
                Session[CartSession] = list;
            }
            return Redirect("/gio-hang");
        }
        public ActionResult UpdateSub(long id)
        {
            var product = new ProductDao().DetailProduct(id);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                foreach (var item in list)
                {
                    if (item.Product.ID == id)
                    {
                        if (item.Quantity > 1)
                        {
                            item.Quantity -= 1;
                        }
                    }
                }
                Session[CartSession] = list;
            }
            return Redirect("/gio-hang");
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string email, string address)
        {
            var order = new Order();
            order.CreatedDate = DateTime.Now;
            order.ShipAddress = address;
            order.ShipName = shipName;
            order.ShipMobile = mobile;
            order.ShipEmail = email;
            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var orderDetailDao = new OrderDetailDao();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    if (item.Product.PromotionPrice == 0 || item.Product.PromotionPrice == null)
                    {
                        orderDetail.Price = item.Product.Price;
                    }
                    else
                    {
                        orderDetail.Price = item.Product.PromotionPrice;
                    }
                    var Product = new ProductDao().DetailProduct(orderDetail.ProductID);
                    orderDetail.ProductName = Product.Name;
                    orderDetail.Quantity = item.Quantity;
                    orderDetailDao.Insert(orderDetail);

                    total += (orderDetail.Price.GetValueOrDefault(0) * item.Quantity);
                }
                //string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Client/template/neworder.html"));
                //content = content.Replace("{{CustomerName}}", shipName);
                //content = content.Replace("{{Phone}}", mobile);
                //content = content.Replace("{{Email}}", email);
                //content = content.Replace("{{Address}}", address);
                //content = content.Replace("{{Total}}", total.ToString());
                //var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                //new MailHelper().SendMail(email, "Đơn hàng mới từ OnlineShop", content);
                //new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);

                Session[CartSession] = null;
            }
            catch(Exception ex)
            {
                throw;
            }
            return Redirect("/");
        }
    }
}