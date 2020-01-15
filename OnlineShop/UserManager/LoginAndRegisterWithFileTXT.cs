using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Models.FE;
using OnlineShop.Models;

namespace OnlineShop.UserManager
{
    public class LoginAndRegisterWithFileTXT: LoginAndRegister
    {
        public override bool CheckUserName(string username)
        {
            return base.CheckUserName(username);
        }

        public override bool CheckEmail(string Email)
        {
            return base.CheckEmail(Email);
        }

        public override long Regiter(User model)
        {
            return base.Regiter(model);
        }

        public override int Login(string username, string password)
        {
            return base.Login(username, password);
        }

        public override User getUserByUsername(string username)
        {
            return base.getUserByUsername(username);
        }        
    }
}