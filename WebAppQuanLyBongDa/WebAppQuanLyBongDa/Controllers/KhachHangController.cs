using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppQuanLyBongDa.Models;

namespace WebAppQuanLyBongDa.Controllers
{
    public class KhachHangController : Controller
    {
        Entities db = new Entities();
        // GET: KhachHang
        public ActionResult DanhSachKhachHang()
        {
            var ds = db.KHACHHANGs.ToList();
            return View(ds);
        }

        // GET: KhachHang/Create
        public ActionResult ThemKhachHang()
        {
            return View();
        }

        // POST: KhachHang/Create
        [HttpPost]
        public ActionResult ThemKhachHang(KHACHHANG khachHang)
        {
            if (ModelState.IsValid)
            {
                KHACHHANG kh = new KHACHHANG();
                kh.MAKH = khachHang.MAKH;
                kh.TENKH = khachHang.TENKH;
                kh.SDTKH = khachHang.SDTKH;
                kh.DIACHIKH = khachHang.DIACHIKH;
                db.KHACHHANGs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("DanhSachKhachHang");
            }
            return View(khachHang);
        }

        // GET: KhachHang/Edit/5
        public ActionResult SuaKhachHang(int id)
        {

             KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MAKH == id);
            if (kh == null)
            {   
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }

        // POST: KhachHang/Edit/5
        [HttpPost]
        public ActionResult SuaKhachHang(int id, KHACHHANG khachHang)
        {
            if (ModelState.IsValid)
            {
                var suaKhachHang = db.KHACHHANGs.SingleOrDefault(n => n.MAKH == khachHang.MAKH);
                suaKhachHang.TENKH = suaKhachHang.TENKH;
                suaKhachHang.SDTKH = suaKhachHang.SDTKH;
                suaKhachHang.DIACHIKH = suaKhachHang.DIACHIKH;
                UpdateModel(suaKhachHang);
                db.SaveChanges();
                return RedirectToAction("DanhSachKhachHang");
            }
            return View(khachHang);
        }

        // GET: KhachHang/Delete/5
        public ActionResult XoaKhachHang(int id)
        {

            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MAKH == id);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }

        // POST: KhachHang/Delete/5
        [HttpPost]
        public ActionResult XoaKhachHang(int id, KHACHHANG khachHang)
        {
            var xoaKhachHang = db.KHACHHANGs.SingleOrDefault(n => n.MAKH == id);
            db.KHACHHANGs.Remove(xoaKhachHang);
            db.SaveChanges();
            return RedirectToAction("DanhSachKhachHang");
        }
    }
}
