using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời nhật UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời nhật Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}