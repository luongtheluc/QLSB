using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppQuanLyBongDa.Models;
using System.IO;
using WebAppQuanLyBongDa.Libs;

namespace WebAppQuanLyBongDa.Controllers
{
    public class AdminController : Controller
    {
        Entities db = new Entities();
        // GET: Admin
        public ActionResult TrangChu()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f, TAIKHOAN t)
        {
            var dn = f["TenDangNhap"];
            var mk = Encrypt.MaHoaMD5(t.MATKHAU);
            if (String.IsNullOrEmpty(dn))
            {
                ViewData["Loi1"] = "Vui lòng nhập tên đăng nhập";
            }

            if (String.IsNullOrEmpty(mk))
            {
                ViewData["Loi2"] = "Vui lòng nhập mật khẩu";
            }
            else
            {
                TAIKHOAN tk = db.TAIKHOANs.SingleOrDefault(n => n.TENTK == dn && n.MATKHAU == mk);
                if (tk != null)
                {
                    Session["Taikhoanadmin"] = tk;
                    Session["Tenhienthiadmin"] = tk.TENHIENTHI;
                    Session["Chucvuadmin"] = tk.VAITRO;
                    return RedirectToAction("TrangChu", "Admin");
                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu sai";
                }
            }
            return View();
        }
    }
}