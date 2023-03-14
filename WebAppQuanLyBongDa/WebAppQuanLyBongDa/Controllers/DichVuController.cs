using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppQuanLyBongDa.Models;

namespace WebAppQuanLyBongDa.Controllers
{
    public class DichVuController : Controller
    {
        Entities db = new Entities();
        // GET: DichVu
        public ActionResult DanhSachDichVu()
        {
            var ds = db.DICHVUs.ToList();
            return View(ds);
        }

        //Thêm dịch vụ
        public ActionResult ThemDichVu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemDichVu(DICHVU dichVu)
        {
            if (ModelState.IsValid)
            {
                DICHVU dv = new DICHVU();
                dv.TENDICHVU = dichVu.TENDICHVU;
                dv.GIATIEN = dichVu.GIATIEN;
                db.DICHVUs.Add(dv);
                db.SaveChanges();
                return RedirectToAction("DanhSachDichVu");
            }
            return View(dichVu);
        }

        //Chi tiết dịch vụ
        public ActionResult ChiTietDichVu(int id)
        {
            DICHVU dv = db.DICHVUs.SingleOrDefault(n => n.MADICHVU == id);
            if (dv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dv);
        }

        //Sửa dịch vụ
        public ActionResult SuaDichVu(int id)
        {
            DICHVU dv = db.DICHVUs.SingleOrDefault(n => n.MADICHVU == id);
            if (dv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaDichVu(DICHVU dichVu)
        {
            if (ModelState.IsValid)
            {
                var suaDichVu = db.DICHVUs.SingleOrDefault(n => n.MADICHVU == dichVu.MADICHVU);
                suaDichVu.TENDICHVU = dichVu.TENDICHVU;
                suaDichVu.GIATIEN = dichVu.GIATIEN;
                UpdateModel(suaDichVu);
                db.SaveChanges();
                return RedirectToAction("DanhSachDichVu");
            }
            return View(dichVu);
        }

        //Xóa dịch vụ
        public ActionResult XoaDichVu(int id)
        {
            DICHVU dv = db.DICHVUs.SingleOrDefault(n => n.MADICHVU == id);
            if (dv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XoaDichVu(int id, DICHVU dichVu)
        {
            var xoaDichVu = db.DICHVUs.SingleOrDefault(n => n.MADICHVU == id);
            db.DICHVUs.Remove(xoaDichVu);
            db.SaveChanges();
            return RedirectToAction("DanhSachDichVu");
        }
    }
}