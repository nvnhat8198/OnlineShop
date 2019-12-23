using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }
        [Required(ErrorMessage ="Yêu cầu nhập username")]
        public string UserName { get; set; }

        [StringLength(20, MinimumLength =6, ErrorMessage ="Tối thiểu 6 kí tự")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string Name { get; set; }


        public string Address { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Email")]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string ProvinceID { get; set; }

        public string DistrictID { get; set; }
    }
}