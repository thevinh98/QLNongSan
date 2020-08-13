using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Models.Dao
{
    public class OrderDao
    {
        QLNSDbContext db = null;
        public OrderDao()
        {
            db = new QLNSDbContext();
        }
        public int Insert(tblOrder order)
        {
            try
            {
                db.tblOrders.Add(order);
                db.SaveChanges();
                return order.ID;
            }
            catch
            {

            }
            return 1;
        }
    }
}