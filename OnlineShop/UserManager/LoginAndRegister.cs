using Models.FE;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.UserManager
{
    public class LoginAndRegister
    {
        public virtual bool CheckUserName(string username)
        {
            return false;
        }

        public virtual bool CheckEmail(string Email)
        {
            return false;
        }
        public virtual long Regiter(User model)
        {
            return 0;
        }

        public virtual int Login(string username , string password)
        {
            return 0;
        }

        public virtual User getUserByUsername(string username)
        {
            return null;
        }
    }
}