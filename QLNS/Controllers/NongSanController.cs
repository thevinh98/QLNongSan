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
    public class NongSanController : Controller
    {
        // GET: NongSan\
        QLNSDbContext db = new QLNSDbContext();
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;

           
            int pageSize = 5;

           
            int pageNumber = (page ?? 1);

            var item = db.NongSans.OrderBy(x => x.ten_ns).ToPagedList(pageNumber, pageSize);
            return View(item);

            
        }
        public void SetViewBag1(string id = null)
        {
            var dao = new NhomNSDao();
            ViewBag.ma_nhom_ns = new SelectList(dao.ListAllNHNS(), "ma_nhom_ns", "ten_nhom_ns", id);
        }
        public void SetViewBag2(string id = null)
        {
            var dao = new ChatLuongDao();
            ViewBag.ma_chat_luong = new SelectList(dao.ListAllCL(), "ma_chat_luong", "ten_chat_luong", id);
        }
        public void SetViewBag3(string id = null)
        {
            var dao = new DiaLyDao();
            ViewBag.ma_vi_tri = new SelectList(dao.ListAllDL(), "ma_vi_tri", "dia_chi", id);
        }
        public ActionResult Create()
        {
            SetViewBag1();
            SetViewBag2();
            SetViewBag3();
            var a = new NongSan();
            return View(a);
        }
        [HttpPost]
        public ActionResult Create(NongSan model)
        {
            SetViewBag1();
            SetViewBag2();
            SetViewBag3();
            if (ModelState.IsValid)
            {
                var dao = new NongSanDao();
                string id = dao.Insert(model);
                return RedirectToAction("Index", "NongSan");

            }
            return View("Index");
        }
        public ActionResult Edit(string id)
        {
            SetViewBag1();
            SetViewBag2();
            SetViewBag3();
            var a = new NongSanDao().GetByMaNS(id);
            return View(a);
        }
        [HttpPost]
        public ActionResult Edit(NongSan model)
        {
            SetViewBag1();
            SetViewBag2();
            SetViewBag3();
            if (ModelState.IsValid)
            {
                var dao = new NongSanDao();
                var res = dao.Update(model);
                return RedirectToAction("Index", "NongSan");

            }
            return View("Index");
        }
        public ActionResult Delete(string id)
        {
            new NongSanDao().Delete(id);  
            return RedirectToAction("Index", "NongSan");
        }
        public ActionResult SearchThongTin(string search, int? page)
        {

            if (page == null) page = 1;


            int pageSize = 5;


            int pageNumber = (page ?? 1);

            var item = db.NongSans.OrderBy(x => x.ten_ns).Where(x => x.ten_ns.Contains(search) || x.ma_ns.Contains(search)).ToPagedList(pageNumber, pageSize);
            return View("Index", item);


        }
        public ActionResult Detail(string id)
        {
            try
            {
                var a = new NongSanDao().GetByMaNS(id);
                ViewBag.NSVT = new NongSanDao().NSCungViTri(a.ma_vi_tri);
                ViewBag.VitriNongSan = new DiaLyDao().ViTriNS(a.ma_vi_tri);
                return View(a);
            }
            catch { }
            return RedirectToAction("Index", "Home");
        }
        
    }
}