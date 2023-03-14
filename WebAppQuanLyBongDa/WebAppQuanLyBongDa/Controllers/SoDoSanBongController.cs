using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using WebAppQuanLyBongDa.Models;

namespace WebAppQuanLyBongDa.Controllers
{
    public class SoDoSanBongController : Controller
    {
        // GET: SoDoSanBong
        private Entities db = new Entities();
        public ActionResult SanBong()
        {
            var sodo = db.SANs.ToList();
            return View(sodo);
        }

    }
}
