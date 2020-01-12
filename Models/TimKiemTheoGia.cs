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
            string tmp = (string)keyword;
            double Num;
            bool isNum = double.TryParse(tmp, out Num);
            if (isNum)
            {
                decimal price = decimal.Parse(tmp);
                return db.Products.Where(x => (x.Price >= (price - 10) && x.Price <= (price + 10)) || (x.PromotionPrice >= (price - 10) && x.PromotionPrice <= (price + 10))).ToList();
            }
            else
            {
                return new List<Product>();

            }

            //return db.Products.Where(x => (x.Price >=((decimal)(keyword) - 10) && x.Price <= ((decimal)(keyword) + 10))
            //                            //|| (x.PromotionPrice >= ((decimal)(keyword) - 10) && x.PromotionPrice <= ((decimal)(keyword) + 10))
            //                         ).ToList();
        }
    }
}