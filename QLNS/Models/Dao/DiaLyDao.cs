using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Models.Dao
{
    public class DiaLyDao
    {
        QLNSDbContext db = null;
        public DiaLyDao()
        {
            db = new QLNSDbContext();
        }

        public DiaLy GetByMaDL(string a)
        {
            return db.DiaLies.Find(a);
        }

        public string Insert(DiaLy a)
        {
            try
            {
                db.DiaLies.Add(a);
                db.SaveChanges();
                return a.ma_vi_tri;
            }
            catch
            {
                return "0";
            }
        }
        public bool Delete(string a)
        {
            try
            {
                var us = db.DiaLies.Find(a);
                db.DiaLies.Remove(us);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<DiaLy> ListAllDL()
        {
            return db.DiaLies.ToList();
        
        }
        public List<DiaLy> ViTriNS(string a)
        {
            return db.DiaLies.Where(x => x.ma_vi_tri == a).ToList();
        }
       
        public bool Update(DiaLy a)
        {
            try
            {
                var b = db.DiaLies.Find(a.ma_vi_tri);//c: mã mới
                b.ma_vi_tri = a.ma_vi_tri;
                b.dia_chi = a.dia_chi;
                b.mo_ta = a.mo_ta;
                b.chi_tiet = a.chi_tiet;
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