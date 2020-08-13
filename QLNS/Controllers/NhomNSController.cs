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
    public class NhomNSController : Controller
    {
        // GET: NhomNS
        QLNSDbContext db = new QLNSDbContext();

        public ActionResult Index(int? page)
        {

            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var item = db.NhomNS.OrderBy(x=>x.ten_nhom_ns).ToPagedList(pageNumber,pageSize);
            return View(item);
        }

        public ActionResult Delete(string id)
        {
            new NhomNSDao().Delete(id);
            return RedirectToAction("Index", "NhomNS");
        }

        public ActionResult Create()
        {
            var a = new NhomN();
            return View(a);
        }
        [HttpPost]
        public ActionResult Create(NhomN model)
        {
            var dao = new NhomNSDao();
            string id = dao.Insert(model);
            return RedirectToAction("Index", "NhomNS");

            //if (ModelState.IsValid)
            //{

            //}
            //return View("Index");
        }
        public ActionResult Edit(string id)
        {
            var a = new NhomNSDao().GetByMaNns(id);
            return View(a);
        }
        [HttpPost]
        public ActionResult Edit(NhomN model)
        {
            var dao = new NhomNSDao();
            var res = dao.Update(model);
            return RedirectToAction("Index", "NhomNS");

            //if (ModelState.IsValid)
            //{
            //}
            //return View("Index");
        }
        public ActionResult SearchThongTin(string search, int? page)
        {

            if (page == null) page = 1;


            int pageSize = 5;


            int pageNumber = (page ?? 1);

            var item = db.NhomNS.OrderBy(x => x.ten_nhom_ns).Where(x => x.ten_nhom_ns.Contains(search)).ToPagedList(pageNumber, pageSize);
            return View("Index", item);


        }
    }
}