using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppQuanLyBongDa.Models;

namespace WebAppQuanLyBongDa.Controllers
{
    public class BaoCaoDoanhThuController : Controller
    {
       Entities db = new Entities();
        // GET: BaoCaoDoanhThu
        public ActionResult DoanhThu()
        {
            var chitietphieudatsan = db.CHITIET_PHIEUDATSAN.ToList();
            ViewBag.chitietphieudatsans = chitietphieudatsan;
            return View(chitietphieudatsan);
        }
    }
}