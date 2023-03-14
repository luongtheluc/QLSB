using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WebAppQuanLyBongDa.Models;

namespace WebAppQuanLyBongDa.Controllers
{
    public class BaoCaoController : Controller
    {
        Entities db = new Entities();
        // GET: BaoCao
        public ActionResult BaoCaoThongKe()
        {
            var phieudatsan = db.PHIEUDATSANs.ToList();
            ViewBag.phieudatsans = phieudatsan;

            return View(phieudatsan);
            
        }
    }
}