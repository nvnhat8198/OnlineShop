using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class ProductDao
    {
        // Quản lý tìm kiếm theo các yêu cầu
        private static SearchManager[] listSearch = new SearchManager[]{
            new SearchByPrice(),
            new SearchByDescription(),
            new SearchByName()
        };
        private SearchManager s = listSearch[1];  // Tìm kiếm theo mô tả

        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }

        public List<Product> ListProduct(long parentId)
        {
            return db.Products.Where(x => x.Status == true && x.CategoryID == parentId).ToList();
        }

        public Product DetailProduct(long id)
        {
            return db.Products.Find(id);
        }

        public List<Product> ListProductPromotion()
        {
            return db.Products.Where(x => x.PromotionPrice > 0 && x.Status == true).Take(6).ToList();
        }

        public List<Product> ListProductNew()
        {
            return db.Products.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(7).ToList();
        }

        public Menu ProductType(long id)
        {
            return db.Menus.Find(id);
        }

        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }

        public List<Product>Search(string keyword, ref int totalRecord, int pageIndex=1, int pageSize=1)
        {
            //var model = db.Products.Where(x => x.Name.Contains(keyword));
            var model = s.Search(keyword);
            totalRecord = model.Count();
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        public List<Product> getAllProduct()
        {
            return db.Products.ToList();
        }

        public bool ChangeStatus(long id)
        {
            var product = db.Products.Find(id);
            product.Status = !product.Status;
            db.SaveChanges();
            return product.Status;
        }

        public void Delete(long id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public List<Menu> ListProductCategory()
        {
            var model = db.Menus.Where(x => x.TypeID != 0).ToList();
            return model;
        }

        public void InsertProduct(Product model)
        {
            db.Products.Add(model);
            db.SaveChanges();
        }

        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ID);
                product.Name = entity.Name;
                product.Description = entity.Description;
                product.Image = entity.Image;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                if(entity.CategoryID!=0 || entity.CategoryID != null)
                {
                    product.CategoryID = entity.CategoryID;
                }
                product.ModifieDate = DateTime.Now;
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
