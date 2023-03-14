using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppQuanLyBongDa.Models;

namespace WebAppQuanLyBongDa.Controllers
{
    public class PhieuDatSanController : Controller
    {
        private Entities db = new Entities();
        // GET: PhieuDatSan
        public ActionResult DanhSachPhieuDatSan()
        {
            var ds = db.PHIEUDATSANs.ToList();
            return View(ds);
        }

        // GET: PhieuDatSan/ChiTietPhieuDatSan/3
        public ActionResult ChiTietPhieuDatSan(int id)
        {
            var chitietphieudat = db.CHITIET_PHIEUDATSAN.Where(p => p.MAPDS == id).FirstOrDefault();
            return View(chitietphieudat);
        }

        // GET: PhieuDatSan/ThemPhieuDatSan
        [HttpGet]
        public ActionResult ThemPhieuDatSan()
        {
            ViewBag.MAKH = new SelectList(db.KHACHHANGs.ToList().OrderBy(n => n.TENKH), "MAKH", "TENKH");
            ViewBag.MANV = new SelectList(db.NHANVIENs.ToList().OrderBy(n => n.TENNV), "MANV", "TENNV");
            return View();
        }

        // POST: PhieuDatSan/ThemPhieuDatSan
        [HttpPost]
        public ActionResult ThemPhieuDatSan(PHIEUDATSAN pHIEUDATSAN)
        {
            if (ModelState.IsValid)
            {
                PHIEUDATSAN pds = new PHIEUDATSAN();
                pds.NGAYDATSAN = pHIEUDATSAN.NGAYDATSAN;
                pds.GIODATSAN = pHIEUDATSAN.GIODATSAN;
                pds.NGAYLAPPDS = pHIEUDATSAN.NGAYLAPPDS;
                pds.MAKH = pHIEUDATSAN.MAKH;
                pds.MANV = pHIEUDATSAN.MANV;
                db.PHIEUDATSANs.Add(pds);
                db.SaveChanges();
                return RedirectToAction("DanhSachPhieuDatSan");
            }
            return View(pHIEUDATSAN);
        }

        // GET: PhieuDatSan/SuaPhieuDatSan/3
        public ActionResult SuaPhieuDatSan(int id)
        {
            PHIEUDATSAN pds = db.PHIEUDATSANs.SingleOrDefault(n => n.MAPDS == id);
            if (pds == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(pds);
           
        }

        // POST: PhieuDatSan/SuaPhieuDatSan/
        [HttpPost]
        public ActionResult SuaPhieuDatSan(PHIEUDATSAN pHIEUDATSAN)
        {

            if (ModelState.IsValid)
            {
                var suaPhieuDatSan = db.PHIEUDATSANs.SingleOrDefault(n => n.MAPDS == pHIEUDATSAN.MAPDS);
                suaPhieuDatSan.NGAYDATSAN = suaPhieuDatSan.NGAYDATSAN;
                suaPhieuDatSan.GIODATSAN = suaPhieuDatSan.GIODATSAN;
                suaPhieuDatSan.NGAYLAPPDS = suaPhieuDatSan.NGAYLAPPDS;
                suaPhieuDatSan.MAKH = suaPhieuDatSan.MAKH;
                suaPhieuDatSan.MANV = suaPhieuDatSan.MANV;
                UpdateModel(suaPhieuDatSan);
                db.SaveChanges();
                return RedirectToAction("DanhSachPhieuDatSan");
            }
            return View(pHIEUDATSAN);
        }

        // GET: PhieuDatSan/Delete/3
        public ActionResult XoaPhieuDatSan(int id)
        {
            PHIEUDATSAN pds = db.PHIEUDATSANs.SingleOrDefault(n => n.MAPDS == id);
            if (pds == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(pds);
            
        }

        // POST: PhieuDatSan/XoaPhieuDatSan/3
        [HttpPost]
        public ActionResult XoaPhieuDatSan(int id, PHIEUDATSAN pHIEUDATSAN)
        {
            var xoaPhieuDatSan = db.PHIEUDATSANs.SingleOrDefault(n => n.MAPDS == id);
            db.PHIEUDATSANs.Remove(xoaPhieuDatSan);
            db.SaveChanges();
            return RedirectToAction("DanhSachPhieuDatSan");

        }
    }
}
