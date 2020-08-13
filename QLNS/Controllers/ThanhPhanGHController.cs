using Common;
using QLNS.Models.Dao;
using QLNS.Models.EF;
using QLNS.Models.Function;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QLNS.Controllers
{
    public class ThanhPhanGHController : Controller
    {
        QLNSDbContext db = new QLNSDbContext();
        private const string key = "key";
        // GET: ThanhPhanGH
        public ActionResult Index()
        {
            var cart = Session[key];
            var list = new List<TpGioHang>();
            if(cart != null)
            {
                list = (List<TpGioHang>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(string ma_ns, int sl)
        {
            var ns = new NongSanDao().GetByMaNS(ma_ns);
            var cart = Session[key];
            //neu key da co trong gio hang thi cong them sl vao
            if(cart != null)
            {
                var list = (List<TpGioHang>)cart;
                if(list.Exists(X => X.nongsan.ma_ns == ma_ns))
                {
                    foreach (var item in list)
                    {
                        if (item.nongsan.ma_ns == ma_ns)
                        {
                            item.so_luong += sl;
                        }
                    }
                }
                else
                {
                    //tao moi doi tuong thanh phan gio hang
                    var item = new TpGioHang();
                    item.nongsan = ns;
                    item.so_luong = sl;
                    list.Add(item);
                }
                //gan vao session
                Session[key] = list;
            }

            //nguoc lai neu chua co thi add vao gio
            else
            {
                //tao moi doi tuong thanh phan gio hang
                var item = new TpGioHang();
                item.nongsan = ns;
                item.so_luong = sl;
                var list = new List<TpGioHang>();
                list.Add(item);
                //gan vao session
                Session[key] = list;
            }
            return RedirectToAction("Index");
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<TpGioHang>>(cartModel);
            var sessionCart = (List<TpGioHang>)Session[key];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.nongsan.ma_ns == item.nongsan.ma_ns);
                if(jsonItem != null)
                {
                    item.so_luong = jsonItem.so_luong;
                }
            }
            Session[key] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteCart()
        {
            Session[key] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(string ma)
        {
            var sessionCart = (List<TpGioHang>)Session[key];
            sessionCart.RemoveAll(x => x.nongsan.ma_ns == ma);
            Session[key] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult ThanhToan()
        {
            var cart = Session[key];
            var list = new List<TpGioHang>();
            if (cart != null)
            {
                list = (List<TpGioHang>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult ThanhToan(string ten_kh, string sdt_kh, string dia_chi_kh, string email_kh)
        {
            var order = new tblOrder();
            order.ngay_tao = DateTime.Now;
            order.ten_kh = ten_kh;
            order.sdt_kh = sdt_kh;
            order.dia_chi_kh = dia_chi_kh;
            order.email_kh = email_kh;
            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<TpGioHang>)Session[key];
                var ctDao = new ChiTietOrderDao();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var b = db.NongSans.Find(item.nongsan.ma_ns);//c: mã mới
                    if(item.so_luong > b.sl_trong_kho)
                    {
                        Response.Write("<script language='javascript'>alert('Số lượng "+ item.nongsan.ten_ns +" trong kho còn ít hơn số lượng bạn cần mua!. Vui lòng mua ít hơn.');</script>");
                    }
                    else
                    {
                        var ctOrder = new ChiTietOrder();
                        ctOrder.ma_ns = item.nongsan.ma_ns;
                        ctOrder.order_id = id;
                        ctOrder.gia = item.nongsan.gia_goc;
                        ctOrder.so_luong = item.so_luong;
                        ctDao.Insert(ctOrder);
                        b.sl_trong_kho = b.sl_trong_kho - item.so_luong;
                        b.top_hot = order.ngay_tao;
                        db.SaveChanges();
                        total += (item.nongsan.gia_goc.GetValueOrDefault(0) * item.so_luong);
                        string content = System.IO.File.ReadAllText(Server.MapPath("~/SendMail/guiMail.html"));
                        content = content.Replace("{{CustomerName}}", ten_kh);
                        content = content.Replace("{{Phone}}", sdt_kh);
                        content = content.Replace("{{Email}}", email_kh);
                        content = content.Replace("{{Address}}", dia_chi_kh);
                        content = content.Replace("{{Total}}", total.ToString());
                        var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                        new MailHelper().SendMail(email_kh, "Đơn hàng mới từ Shop chúng tôi", content);
                        new MailHelper().SendMail(toEmail, "Đơn hàng mới từ Shop chúng tôi", content);
                        return View("HoanThanh");
                    }
                    
                    
                }
                
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                return RedirectToAction("Index", "ThanhPhanGH");
            }
            return View("ChuaHoanThanh");
        }
        public ActionResult HoanThanh()
        {
            return RedirectToAction("HoanThanh", "ThanhPhanGH");
        }
    }
}