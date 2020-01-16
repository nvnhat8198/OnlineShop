using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class SearchManager
    {
        public OnlineShopDbContext db = null;
        public SearchManager()
        {
            db = new OnlineShopDbContext();
        }

        public virtual List<Product> Search(object keyword)
        {
            return new List<Product>();
        }
    }
}