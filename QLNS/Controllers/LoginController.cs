using QLNS.Common;
using QLNS.Models.Dao;
using QLNS.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModels model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var res = dao.Login(model.UserName, model.PassWord);
                if (res == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "User");
                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại ^_^");
                }
                else if (res == -1)
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa ^_^");
                }
                else if (res == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng ^_^");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }
            //else
            //{
            //    ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin ^_^");
            //}
            return View("Index");
        }
    }
}