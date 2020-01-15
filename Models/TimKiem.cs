using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class TimKiem
    {
        public OnlineShopDbContext db = null;
        public TimKiem()
        {
            db = new OnlineShopDbContext();
        }

        public virtual List<Product> Search(object keyword)
        {
            return new List<Product>();
        }
    }
}