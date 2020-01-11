using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.FE;

namespace Models
{
    public class TimKiemTheoMoTa : TimKiem
    {
        public override List<Product> Search(object keyword)
        {
            return db.Products.Where(x => x.Description.Contains((string)keyword)).ToList();
        }
    }
}