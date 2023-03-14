using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppQuanLyBongDa.Models;

namespace WebAppQuanLyBongDa.Controllers
{
    public class PhieuThanhToanController : Controller
    {
        Entities db = new Entities();
        // GET: PhieuThanhToan
        public ActionResult DanhSachPhieuThanhToan()
        {
            var ds = db.PHIEUTHANHTOANs.ToList();
            return View(ds);
        }

        // GET: PhieuThanhToan/Create
        public ActionResult ThemPhieuThanhToan()
        {
            return View();
        }

        // POST: PhieuThanhToan/Create
        [HttpPost]
        public ActionResult ThemPhieuThanhToan(PHIEUTHANHTOAN pHIEUTHANHTOAN)
        {
            if (ModelState.IsValid)
            {
                PHIEUTHANHTOAN ptt = new PHIEUTHANHTOAN();
                ptt.MAPTT = pHIEUTHANHTOAN.MAPTT;
                ptt.NGAYLAPPTT = pHIEUTHANHTOAN.NGAYLAPPTT;
                ptt.TONGTIEN = pHIEUTHANHTOAN.TONGTIEN;
                ptt.MANV = pHIEUTHANHTOAN.MANV;
                db.PHIEUTHANHTOANs.Add(ptt);
                db.SaveChanges();
                return RedirectToAction("DanhSachPhieuThanhToan");
            }
            return View(pHIEUTHANHTOAN);
        }

        // GET: KhachHang/Edit/5
        public ActionResult SuaPhieuThanhToan(int id)
        {

            PHIEUTHANHTOAN ptt = db.PHIEUTHANHTOANs.SingleOrDefault(n => n.MAPTT == id);
            if (ptt == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ptt);
        }

        // POST: KhachHang/Edit/5
        [HttpPost]
        public ActionResult SuaPhieuThanhToan(int id, PHIEUTHANHTOAN pHIEUTHANHTOAN)
        {
            if (ModelState.IsValid)
            {
                var suaPhieuThanhToan = db.PHIEUTHANHTOANs.SingleOrDefault(n => n.MAPTT == pHIEUTHANHTOAN.MAPTT);
                suaPhieuThanhToan.NGAYLAPPTT = suaPhieuThanhToan.NGAYLAPPTT;
                suaPhieuThanhToan.TONGTIEN = suaPhieuThanhToan.TONGTIEN;
                suaPhieuThanhToan.MANV = suaPhieuThanhToan.MANV;
                UpdateModel(suaPhieuThanhToan);
                db.SaveChanges();
                return RedirectToAction("DanhSachPhieuThanhToan");
            }
            return View(pHIEUTHANHTOAN);
        }
    }
}
