using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class MenuDao
    {
        OnlineShopDbContext db = null;
        public MenuDao()
        {
            db = new OnlineShopDbContext();
        }

        public List<Menu> ListMenu()
        {
            return db.Menus.Where(x=>x.Status == true).ToList();
        }

        public List<Menu> listProductCategory()
        {
            return db.Menus.Where(x => x.Status == true && x.TypeID > 0).ToList();
        }
    }
}
