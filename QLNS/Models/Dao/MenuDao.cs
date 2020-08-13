using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Models.Dao
{
    public class MenuDao
    {
        QLNSDbContext db = null;
        public MenuDao()
        {
            db = new QLNSDbContext();
        }
        public List<Menu> ListByIdGroupId(int Idloaimenu)
        {
            return db.Menus.Where(x => x.ID_loai_menu == Idloaimenu).ToList();
        }

        public List<NhomN> ListCatory()
        {
            return db.NhomNS.ToList();
        }
        public Menu GetMenuById(int id)
        {
            return db.Menus.SingleOrDefault(x => x.ID == id);
        }
        
        public bool Delete(int id)
        {
            try
            {
                var us = db.Menus.Find(id);
                db.Menus.Remove(us);
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
                var us = db.Menus.Find(id);
                db.Menus.Remove(us);
                db.SaveChanges();
                return us.ID;
            }
            catch
            {
                return 0;
            }
        }
        public List<LoaiMenu> ListAll1()
        {
            return db.LoaiMenus.ToList();
        }
        //tìm kiếm

        public List<NongSan> SearchNS(string search)
        {
            return db.NongSans.Where(x => x.ten_ns.Contains(search) || x.DiaLy.dia_chi.Contains(search) || x.NhomN.ten_nhom_ns.Contains(search)).ToList();

            //if (search.Length == 0)
            //{
            //    return db.NongSans.ToList();
            //}
            //else
            //{
            //}
        }

        //lasays id nhóm ns
        public NhomN GetByMaNNS(string a)
        {
            return db.NhomNS.Find(a);
        }

        public List<NongSan> NSCungNhom(string nhns)
        {
            //OrderByDescending: giam dan
            return db.NongSans.Where(x => x.ma_nhom_ns == nhns).ToList();

        }
        public List<NhomN> NNS(string id)
        {
            return db.NhomNS.Where(x => x.ma_nhom_ns == id).ToList();
        }

    }
}