using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string GroupID { get; set; }

        // Bổ sung thêm thuộc tính cho phần Checkout
        public string ShipName { get; set; }
        public string ShipMobile { get; set; }
        public string ShipEmail { get; set; }
        public string ShipAddress { get; set; }
    }
}