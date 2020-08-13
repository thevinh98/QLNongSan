using QLNS.Models.Dao;
using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace QLNS.Controllers
{
    public class ChatLuongController : Controller
    {
        QLNSDbContext db = new QLNSDbContext();

        public ActionResult Index(int? page)
        {

            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var item = db.ChatLuongs.OrderBy(x=>x.ten_chat_luong).ToPagedList(pageNumber, pageSize);
            return View(item);
        }

        public ActionResult Delete(string id)
        {
            new ChatLuongDao().Delete(id);
            return RedirectToAction("Index", "ChatLuong");
        }

        public ActionResult Create()
        {
            var a = new ChatLuong();
            return View(a);
        }
        [HttpPost]
        public ActionResult Create(ChatLuong model)
        {
            if(ModelState.IsValid)
            {
                var dao = new ChatLuongDao();
                string id = dao.Insert(model);
                return RedirectToAction("Index", "ChatLuong");

            }
            return View("Index");
        }
        public ActionResult Edit(string id)
        {
            var a = new ChatLuongDao().GetByMaCL(id);
            return View(a);
        }
        [HttpPost]
        public ActionResult Edit(ChatLuong model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChatLuongDao();
                var res = dao.Update(model);
                return RedirectToAction("Index", "ChatLuong");

            }
            return View("Index");
        }
        public ActionResult SearchThongTin(string search, int? page)
        {

            if (page == null) page = 1;


            int pageSize = 5;


            int pageNumber = (page ?? 1);

            var item = db.ChatLuongs.OrderBy(x => x.ten_chat_luong).Where(x => x.ten_chat_luong.Contains(search)).ToPagedList(pageNumber, pageSize);
            return View("Index", item);


        }
    }
}