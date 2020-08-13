using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Models.Dao
{
    public class NhomNSDao
    {
        QLNSDbContext db = null;
        public NhomNSDao()
        {
            db = new QLNSDbContext();
        }

        public NhomN GetByMaNns(string a)
        {
            return db.NhomNS.Find(a);
        }
        public List<NhomN> ListAllNHNS()
        {
            return db.NhomNS.ToList();
        }
        public string Insert(NhomN a)
        {
            try
            {
                db.NhomNS.Add(a);
                db.SaveChanges();
                return a.ma_nhom_ns;
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
                var us = db.NhomNS.Find(a);
                db.NhomNS.Remove(us);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(NhomN a)
        {
            try
            {
                var b = db.NhomNS.Find(a.ma_nhom_ns);//c: mã mới
                b.ma_nhom_ns = a.ma_nhom_ns;
                b.ten_nhom_ns = a.ten_nhom_ns;
                b.tieu_de_url = a.tieu_de_url;
                b.ID_cha = a.ID_cha;
                b.tieu_de_tk = a.tieu_de_tk;
                b.ngay_tao = a.ngay_tao;
                b.nguoi_tao = a.nguoi_tao;
                b.ngay_sua = a.ngay_sua;
                b.nguoi_sua = a.nguoi_sua;
                b.tinh_trang = a.tinh_trang;
                b.tu_khoa_tk = a.tu_khoa_tk;
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