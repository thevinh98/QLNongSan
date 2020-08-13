using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Models.Dao
{
    public class NongSanDao
    {
        QLNSDbContext db = null;
        public NongSanDao()
        {
            db = new QLNSDbContext();
        }
        public List<NongSan> ListAllNS()
        {
            //OrderByDescending: giam dan
            return db.NongSans.ToList();

        }
        public List<NongSan> NSMoi(int sl)
        {
            //OrderByDescending: giam dan
            return db.NongSans.OrderByDescending(x => x.tao_ngay).Take(12).ToList();

        }
        
        public List<NongSan> NSBanChay(int sl)
        {
            //OrderByDescending: giam dan
            return db.NongSans.Where(x => x.top_hot != null).OrderByDescending(x => x.top_hot).Take(6).ToList();
        }
        public List<NongSan> NSCungViTri(string vt)
        {
            //var a = new NongSanDao().GetByMaNS(vt);
            return db.NongSans.Where(x => x.ma_vi_tri == vt).ToList();

        }
        public string Insert(NongSan a)
        {
            try
            {
                db.NongSans.Add(a);
                db.SaveChanges();
                return a.ma_ns;
            }
            catch
            {
                return "0";
            }
        }
        public NongSan GetByMaNS(string a)
        {
            return db.NongSans.Find(a);
        }
        public bool Update(NongSan a)
        {
            try
            {
                var b = db.NongSans.Find(a.ma_ns);//c: mã mới
                b.ma_ns = a.ma_ns;
                b.ten_ns = a.ten_ns;
                b.mo_ta = a.mo_ta;
                b.hinh_anh = a.hinh_anh;
                b.gia_goc = a.gia_goc;
                b.gia_km = a.gia_km ;
                b.chi_tiet = a.chi_tiet;
                b.sl_trong_kho = a.sl_trong_kho;
                b.ma_nhom_ns = a.ma_nhom_ns;
                b.ma_chat_luong = a.ma_chat_luong;
                b.ma_vi_tri = a.ma_vi_tri;
                b.tao_boi = a.tao_boi;
                b.sua_ngay = a.sua_ngay;
                b.sua_boi = a.sua_boi;
                b.top_hot = a.top_hot;
                b.hinh_anh_vt = a.hinh_anh_vt;
                b.link_anh = a.link_anh;
                b.link_chi_tiet = a.link_chi_tiet;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update_order(NongSan a)
        {
            try
            {
                var b = db.NongSans.Find(a.ma_ns);//c: mã mới
                b.sl_trong_kho = a.sl_trong_kho;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(string a)
        {
            try
            {
                var us = db.NongSans.Find(a);
                db.NongSans.Remove(us);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<NongSan> ListAll1()
        {
            return db.NongSans.ToList();
        }
    }
}