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
    public class NhapXuatThuHoachController : Controller
    {
        // GET: NhapXuatThuHoach
        QLNSDbContext db = new QLNSDbContext();

        public ActionResult Index(int? page)
        {

            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var item = db.Nhap_Xuat_ThuHoach.OrderBy(x =>x.tao_ngay).ToPagedList(pageNumber,pageSize);
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            new XuatNhapThuHoachDao().Delete(id);
            return RedirectToAction("Index", "NhapXuatThuHoach");
        }

        public ActionResult Create()
        {
            SetViewBag1();
            var a = new Nhap_Xuat_ThuHoach();
            return View(a);
        }
        [HttpPost]
        public ActionResult Create(Nhap_Xuat_ThuHoach model)
        {
            SetViewBag1();
            var dao = new XuatNhapThuHoachDao();
            int id = dao.Insert(model);
            var a = db.NongSans.Where(x => x.ma_ns == model.ma_ns).FirstOrDefault();
            if (model.loai == true)
            {
                a.sl_trong_kho += model.sl_nhap;
                db.SaveChanges();
            }
            else
            {
                a.sl_trong_kho -= model.sl_xuat;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "NhapXuatThuHoach");

            //if (ModelState.IsValid)
            //{

            //}
            //return View("Index");
        }
        public ActionResult Edit(int id)
        {
            SetViewBag1();
            var a = new XuatNhapThuHoachDao().GetByMaNX(id);
            return View(a);
        }
        [HttpPost]
        public ActionResult Edit(Nhap_Xuat_ThuHoach model)
        {
            SetViewBag1();
            var dao = new XuatNhapThuHoachDao();
            var a = db.NongSans.Where(x => x.ma_ns == model.ma_ns).FirstOrDefault();
            var c = dao.GetSL(model.ID);
            var res = dao.Update(model);
            if(model.loai == true)
            {
                a.sl_trong_kho = a.sl_trong_kho - c +  model.sl_nhap;
                db.SaveChanges();
            }
            else
            {
                a.sl_trong_kho = a.sl_trong_kho + c - model.sl_xuat;
                db.SaveChanges();

            }
            
            return RedirectToAction("Index", "NhapXuatThuHoach");

        }
        public ActionResult SearchThongTin(string search, int? page)
        {

            if (page == null) page = 1;


            int pageSize = 5;


            int pageNumber = (page ?? 1);

            var item = db.Nhap_Xuat_ThuHoach.OrderBy(x => x.ma_ns).Where(x => x.ma_ns.Contains(search)|| x.ma_nx_th.Contains(search)).ToPagedList(pageNumber, pageSize);
            return View("Index", item);


        }
        public void SetViewBag1(string id = null)
        {
            var dao = new XuatNhapThuHoachDao();
            ViewBag.ma_ns = new SelectList(dao.ListAll1(), "ma_ns", "ten_ns", id);
        }
    }
}