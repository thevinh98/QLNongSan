using QLNS.Common;
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
    public class UserController : Controller
    {
        // GET: User
        QLNSDbContext db = new QLNSDbContext();
        public ActionResult Index(int? page)
        {

            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var item = db.accounts.OrderBy(x =>x.ngay_tao).ToPagedList(pageNumber, pageSize);
            return View(item);
        }
        
        public ActionResult Delete(int id)
        {
            try
            {
                var item = db.accounts.Where(x => x.ID.Equals(id)).FirstOrDefault();
                db.accounts.Remove(item);
                db.SaveChanges();
                var item2 = db.accounts.ToList();
                return View("Index", item2);

            }
            catch { }
            return View("Index");
        }
        public ActionResult Create()
        {
            var a = new account();
            return View(a);
        }
        [HttpPost]
        public ActionResult Create(account model)
        {
            try
            {
                account item = new account();
                item.UserName = model.UserName;
                item.PassWord = model.PassWord;
                item.email = model.email;
                item.ngay_tao = model.ngay_tao;
                item.nguoi_tao = model.nguoi_tao;
                item.ngay_sua = model.ngay_sua;
                item.nguoi_sua = model.nguoi_sua;
                item.tinh_trang = model.tinh_trang;
                db.accounts.Add(item);
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
            var item = db.accounts.Where(x => x.ID == id).FirstOrDefault();
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(account model)
        {
            try
            {
                var item = db.accounts.Where(x => x.ID == model.ID).First();
                item.UserName = model.UserName;
                item.PassWord = model.PassWord;
                item.email = model.email;
                item.ngay_tao = model.ngay_tao;
                item.nguoi_tao = model.nguoi_tao;
                item.ngay_sua = model.ngay_sua;
                item.nguoi_sua = model.nguoi_sua;
                item.tinh_trang = model.tinh_trang;
                db.SaveChanges();
                return RedirectToAction("Index", "User");
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

            var item = db.accounts.OrderBy(x => x.UserName).Where(x => x.UserName.Contains(search)).ToPagedList(pageNumber, pageSize);
            return View("Index", item);


        }
    }
}