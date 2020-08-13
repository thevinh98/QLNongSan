using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Models.Dao
{
    public class UserDao
    {
        QLNSDbContext db = null;
        public UserDao()
        {
            db = new QLNSDbContext();
        }
        
        public account GetById(string us)
        {
            return db.accounts.SingleOrDefault(x => x.UserName == us);
        }
        public int Login(string username, string password)
        {
            var res = db.accounts.SingleOrDefault(x => x.UserName == username);
            if (res == null)
            {
                return 0;
            }
            else
            {
                if (res.tinh_trang == false)
                {
                    return -1;
                }
                else
                {
                    if (res.PassWord == password)
                        return 1;
                    else
                        return -2;
                }
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var us = db.accounts.Find(id);
                db.accounts.Remove(us);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int Insert(int id)
        {
            try
            {
                var us = db.accounts.Find(id);
                db.accounts.Remove(us);
                db.SaveChanges();
                return us.ID;
            }
            catch
            {
                return 0;
            }
        }
        //public bool Update(string id)
        //{
        //    try
        //    {
        //        var us = db.accounts.Find(id);
        //        db.accounts.Remove(us);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}