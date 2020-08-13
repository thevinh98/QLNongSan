using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNS.Models.Dao
{
    public class ChatLuongDao
    {
        QLNSDbContext db = null;
        public ChatLuongDao()
        {
            db = new QLNSDbContext();
        }

        public ChatLuong GetByMaCL(string a)
        {
            return db.ChatLuongs.Find(a);
        }
        public List<ChatLuong> ListAllCL()
        {
            return db.ChatLuongs.ToList();
        }
        public string Insert(ChatLuong a)
        {
            try
            {
                db.ChatLuongs.Add(a);
                db.SaveChanges();
                return a.ma_chat_luong;
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
                var us = db.ChatLuongs.Find(a);
                db.ChatLuongs.Remove(us);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ChatLuong a)
        {
            try
            {
                var b = db.ChatLuongs.Find(a.ma_chat_luong);//c: mã mới
                b.ma_chat_luong = a.ma_chat_luong;
                b.ten_chat_luong = a.ten_chat_luong;
                b.PP_SX = a.PP_SX;
                b.KT_dong_goi = a.KT_dong_goi;
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