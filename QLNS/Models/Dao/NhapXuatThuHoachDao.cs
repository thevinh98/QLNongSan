using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Models.Dao
{
    public class XuatNhapThuHoachDao
    {
        QLNSDbContext db = null;
        public XuatNhapThuHoachDao()
        {
            db = new QLNSDbContext();
        }
        public Nhap_Xuat_ThuHoach GetByMaNS(string a)
        {
            return db.Nhap_Xuat_ThuHoach.Where(x => x.ma_ns == a).FirstOrDefault();
        }
        public Nhap_Xuat_ThuHoach GetByMaNX(int a)
        {
            return db.Nhap_Xuat_ThuHoach.Find(a);
        }
        public int GetSL(int a)
        {
            var b = db.Nhap_Xuat_ThuHoach.Find(a);
            if (b.loai == true)
            {
                var c = b.sl_nhap;
                return c;
            }
            else
            {
                var d = b.sl_xuat;
                return d;
            }
        }
        public int Insert(Nhap_Xuat_ThuHoach a)
        {
            try
            {
                db.Nhap_Xuat_ThuHoach.Add(a);
                db.SaveChanges();
                return a.ID;
            }
            catch
            {
                return 0;
            }
        }
        public bool Delete(int a)
        {
            try
            {
                var us = db.Nhap_Xuat_ThuHoach.Find(a);
                db.Nhap_Xuat_ThuHoach.Remove(us);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Nhap_Xuat_ThuHoach a)
        {
            try
            {
                var b = db.Nhap_Xuat_ThuHoach.Find(a.ID);//c: mã mới
                b.ma_nx_th = a.ma_nx_th;
                b.ma_ns = a.ma_ns;
                b.tg_nhap = a.tg_nhap;
                b.sl_nhap = a.sl_nhap;
                b.don_gia_nhap = a.don_gia_nhap;
                b.tg_xuat = a.tg_xuat;
                b.sl_xuat = a.sl_xuat;
                b.don_gia_xuat = a.don_gia_xuat;
                b.tao_ngay = a.tao_ngay;
                b.tao_boi = a.tao_boi;
                b.sua_ngay = a.sua_ngay;
                b.sua_boi = a.sua_boi;
                b.loai = a.loai;
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