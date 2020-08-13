using QLNS.Models.Dao;
using QLNS.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNS.Controllers
{
    public class MenuController : Controller
    {
        QLNSDbContext db = new QLNSDbContext();
        public ActionResult Index()
        {
            var item = db.Menus.ToList();
            return View(item);
        }
        public void SetViewBag1(int id = 0)
        {
            var dao = new MenuDao();
            ViewBag.ten_loai = new SelectList(dao.ListAll1(), "ten_loai", "", id);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var item = db.Menus.Where(x => x.ID.Equals(id)).FirstOrDefault();
                db.Menus.Remove(item);
                db.SaveChanges();
                var item2 = db.Menus.ToList();
                return View("Index", item2);

            }
            catch { }
            return View("Index");
        }
        public ActionResult Create()
        {
            var a = new Menu();
            return View(a);
        }
        [HttpPost]
        public ActionResult Create(Menu model)
        {
            try
            {
                Menu item = new Menu();
                item.tieu_de_menu = model.tieu_de_menu;
                item.link = model.link;
                item.ID_loai_menu = model.ID_loai_menu;
                db.Menus.Add(item);
                db.SaveChanges();
                ViewBag.Message = "Thêm mới thành công";
                return RedirectToAction("Index", "User");
            }
            catch
            {

            }
            return RedirectToAction("Index", "User");

        }
        public ActionResult Edit(int id)
        {
            var item = db.Menus.Where(x => x.ID == id).First();
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Menu model)
        {
            try
            {
                var item = db.Menus.Where(x => x.ID == model.ID).First();
                item.tieu_de_menu = model.tieu_de_menu;
                item.link = model.link;
                item.ID_loai_menu = model.ID_loai_menu;
                db.SaveChanges();
                ViewBag.Message = "Cập nhật thành công!";
                var item2 = db.Menus.ToList();
                return View("Index", item2);
            }
            catch
            {

            }
            return RedirectToAction("Index", "User");
        }
        public ActionResult SearchThongTin(string search, int? page)
        {

            if (page == null) page = 1;


            int pageSize = 5;


            int pageNumber = (page ?? 1);

            var item = db.Menus.Where(x => x.tieu_de_menu.Contains(search)).ToList();
            return View("Index", item);


        }
    }
}