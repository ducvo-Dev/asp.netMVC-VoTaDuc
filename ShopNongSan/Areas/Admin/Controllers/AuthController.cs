using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopNongSan;
using MyLibrary.DAO;
using MyLibrary.Model;

namespace ShopNongSan.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        UserDAO userDao = new UserDAO();
        // GET: Admin/Auth
        public ActionResult Login()
        {
            ViewBag.strError = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection filed)
        {
            String user = filed["username"];
            String pass = MyString.ToMD5( filed["password"]);
            String error = "";
            //xu ly
            User user_row = userDao.getRow(user);
            if(user_row!=null)
            {
                if (user_row.Password.Equals(pass))
                {
                    Session["UserAdmin"] = user_row.Username;
                    Session["UserId"] = user_row.Id.ToString();
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    error = "Sai Mật Khẩu";
                } 
            }
            else
            {
                error ="Tên Đăng nhập không tồn tại" ;
            }

            ViewBag.strError = "<div class='text-danger'>"+ error + "</div>";
            return View();
        }
        public ActionResult Logout()
        {
            Session["UserAdmin"] = "";
            Session["UserId"] = "";
            return Redirect("~/Admin/login");
   
        }
    }
}