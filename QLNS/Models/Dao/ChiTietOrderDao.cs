using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Models.Dao
{
    public class ChiTietOrderDao
    {
        QLNSDbContext db = null;
        public ChiTietOrderDao()
        {
            db = new QLNSDbContext();
        }
        public bool Insert(ChiTietOrder ct)
        {
            try
            {
                db.ChiTietOrders.Add(ct);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}