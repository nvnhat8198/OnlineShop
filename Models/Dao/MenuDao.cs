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
        public bool InsertCategoryProduct(Menu model)
        {
            try
            {
                db.Menus.Add(model);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }

        public Menu ViewDetail(int id)
        {
            return db.Menus.Find(id);
        }

        public bool Update(Menu entity)
        {
            try
            {
                var menu = db.Menus.Find(entity.ID);
                menu.Text = entity.Text;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
