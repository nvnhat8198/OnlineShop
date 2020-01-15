using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Models.FE;
using OnlineShop.Models;
using BotDetect.Web.Mvc;
using CKFinder.Connector;
using Facebook;
using Models.Dao;
using OnlineShop.Common;
using System.Web.Mvc;
using System.Configuration;
using OnlineShop.UserManager;

namespace OnlineShop.UserManager
{
    public class LoginAndRegisterWithXML: LoginAndRegister
    {
        public override bool CheckUserName(string username)
        {
            var xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath(@"~\UserManager\Data\User.xml"));
            var xElements = xmlDoc.Element("Root").Elements("User").Where(x => x.Attribute("UserName").Value == username);
            if (xElements.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool CheckEmail(string Email)
        {
            var xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath(@"~\UserManager\Data\User.xml"));
            var xElements = xmlDoc.Element("Root").Elements("User").Where(x => x.Attribute("Email").Value == Email);
            if (xElements.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override long Regiter(User model)
        {
            var xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath(@"~\UserManager\Data\User.xml"));

            int ID = xmlDoc.Element("Root").Elements("User").Count() + 1;

            string address = "";
            if (model.Address != null) address = model.Address.ToString();
            string phone = "";
            if (model.Phone != null) phone = model.Phone.ToString();

            string provinceID = "";
            if (model.ProvinceID != null) provinceID = model.ProvinceID.ToString();
            string districtID = "";
            if (model.DistrictID != null) districtID = model.DistrictID.ToString();

            XElement el;
            el = new XElement("User",
                    new XAttribute("ID", ID.ToString()),
                    new XAttribute("UserName", model.UserName.ToString()),
                    new XAttribute("Password", model.Password.ToString()),
                    new XAttribute("GroupID", model.GroupID.ToString()),
                    new XAttribute("Name", model.Name.ToString()),
                    new XAttribute("Address", address),
                    new XAttribute("Email", model.Email.ToString()),
                    new XAttribute("Phone", phone),
                    new XAttribute("ProvinceID", provinceID),
                    new XAttribute("DistrictID", districtID),
                    new XAttribute("CreatedDate", model.CreatedDate.ToString()),
                    new XAttribute("CreateBy", ""),
                    new XAttribute("ModifieDate", ""),
                    new XAttribute("ModifieBy", ""),
                    new XAttribute("Status", "1")
            );
            xmlDoc.Element("Root").Add(el);
            xmlDoc.Save(HttpContext.Current.Server.MapPath(@"~\UserManager\Data\User.xml"));
            return ID;
        }
        public override int Login(string username, string password)
        {
            var xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath(@"~\UserManager\Data\User.xml"));
            var xElement = xmlDoc.Element("Root").Elements("User").Where(x => x.Attribute("UserName").Value == username).FirstOrDefault();
            if (xElement == null)
            {
                return 0;
            }
            int status = int.Parse(xElement.Attribute("Status").Value);
            if (status == 0) return -1;
            if (xElement.Attribute("Password").Value.ToString() == password) return 1;
            return -2;
        }

        public override User getUserByUsername(string username)
        {
            var xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath(@"~\UserManager\Data\User.xml"));
            var xElement = xmlDoc.Element("Root").Elements("User").Where(x => x.Attribute("UserName").Value == username).FirstOrDefault();
            User u = new User();
            u.ID = int.Parse(xElement.Attribute("ID").Value);
            u.UserName = xElement.Attribute("UserName").Value.ToString();
            u.GroupID = xElement.Attribute("GroupID").Value.ToString();
            u.Name = xElement.Attribute("Name").Value.ToString();
            u.Phone = xElement.Attribute("Phone").Value.ToString();
            u.Email = xElement.Attribute("Email").Value.ToString();
            u.Address = xElement.Attribute("Address").Value.ToString();
            return u;
        }        
    }
}