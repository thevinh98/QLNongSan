using QLNS.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.AllNS = new NongSanDao().ListAllNS();
            ViewBag.NSMoi = new NongSanDao().NSMoi(12);
            ViewBag.NSBanChay = new NongSanDao().NSBanChay(6);
            ViewBag.NS = new NongSanDao().NSMoi(1);
            return View();
        }
        public ActionResult DangKy()
        {
            return View("DangKy");
        }
        public ActionResult Index_All()
        {
            ViewBag.AllNS = new NongSanDao().ListAllNS();
            return View();
        }
        [ChildActionOnly]
        public ActionResult MenuMain()
        {
            var model = new MenuDao().ListByIdGroupId(36);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Topmenu()
        {
            var model = new MenuDao().ListByIdGroupId(38);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult NhomNS()
        {
            var model = new MenuDao().ListCatory();
            return PartialView(model);
        }
       

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Banner()
        {
            var model = new SlideDao().GetImage();
            return PartialView(model);
        }
        // tìm kiếm 
        public ActionResult SearchThongTin(string Search = null)
        {
            if(Search.Length == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Search = new MenuDao().SearchNS(Search);
                return View();

            }
        }
        //------- hien thi nong san theo từng nhóm------
        public ActionResult MucNS(string id)
        {
            var a = new MenuDao().GetByMaNNS(id);
            ViewBag.NSCN = new MenuDao().NSCungNhom(a.ma_nhom_ns);
            ViewBag.NNS = new MenuDao().NNS(a.ma_nhom_ns);
            return View(a);
        }
    }
}