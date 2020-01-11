using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class OrderDao
    {
        OnlineShopDbContext db = null;
        public OrderDao()
        {
            db = new OnlineShopDbContext();
        }

        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }

        public List<Order> ListOrder()
        {
            return db.Orders.ToList();
        }

        public List<OrderDetail> ListOrderDetail(long id)
        {
            return db.OrderDetails.Where(x => x.OrderID == id).ToList();
        }


        public bool ChangeStatus(long id)
        {
            var order = db.Orders.Find(id);
            order.Status = !order.Status;
            db.SaveChanges();
            return order.Status;
        }
    }

}
