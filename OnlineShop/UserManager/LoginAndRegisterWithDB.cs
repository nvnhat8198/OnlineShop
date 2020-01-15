using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Dao;
using Models.FE;
using OnlineShop.Models;

namespace OnlineShop.UserManager
{
    public class LoginAndRegisterWithDB: LoginAndRegister
    {
        UserDao dao = new UserDao();

        public override bool CheckUserName(string username)
        {
            return dao.CheckUserName(username);
        }

        public override bool CheckEmail(string Email)
        {
            return dao.CheckEmail(Email);
        }

        public override long Regiter(User model)
        {
            return dao.Insert(model);
        }

        public override int Login(string username, string password)
        {
            return dao.Login(username, password);
        }
        public override User getUserByUsername(string username)
        {
            return dao.GetByID(username);
        }        
    }
}