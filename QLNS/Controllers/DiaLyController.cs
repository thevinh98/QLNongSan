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
    public class DiaLyController : Controller
    {

        // GET: DiaLy
        QLNSDbContext db = new QLNSDbContext();

        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var item = db.DiaLies.OrderBy(x=>x.dia_chi).ToPagedList(pageNumber,pageSize);
            return View(item);
        }

        public ActionResult Delete(string id)
        {
            new DiaLyDao().Delete(id);
            return RedirectToAction("Index", "DiaLy");
        }

        public ActionResult Create()
        {
            var a = new DiaLy();
            return View(a);
        }
        [HttpPost]
        public ActionResult Create(DiaLy model)
        {
            
                var dao = new DiaLyDao();
                string id = dao.Insert(model);
                return RedirectToAction("Index", "DiaLy");

            
        }
        public ActionResult Edit(string id)
        {
            var a = new DiaLyDao().GetByMaDL(id);
            return View(a);
        }
        [HttpPost]
        public ActionResult Edit(DiaLy model)
        {
            if (ModelState.IsValid)
            {
                var dao = new DiaLyDao();
                var res = dao.Update(model);
                return RedirectToAction("Index", "DiaLy");

            }
            return View("Index");
        }
        public ActionResult SearchThongTin(string search, int? page)
        {

            if (page == null) page = 1;


            int pageSize = 5;


            int pageNumber = (page ?? 1);

            var item = db.DiaLies.OrderBy(x => x.dia_chi).Where(x => x.dia_chi.Contains(search)).ToPagedList(pageNumber, pageSize);
            return View("Index", item);


        }
    }
}