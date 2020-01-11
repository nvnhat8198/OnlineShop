using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.FE;

namespace Models
{
    public class TimKiemTheoGia : TimKiem
    {
        public override List<Product> Search(object keyword)
        {
            return db.Products.Where(x => (x.Price >=((decimal)(keyword) - 10) && x.Price <= ((decimal)(keyword) + 10))
                                        || (x.PromotionPrice >= ((decimal)(keyword) - 10) && x.PromotionPrice <= ((decimal)(keyword) + 10))
                                     ).ToList();
        }
    }
}