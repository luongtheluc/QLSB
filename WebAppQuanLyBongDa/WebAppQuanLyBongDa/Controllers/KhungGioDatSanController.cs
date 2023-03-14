using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppQuanLyBongDa.Models;

namespace WebAppQuanLyBongDa.Controllers
{
    public class KhungGioDatSanController : ApiController
    {
        Entities db = new Entities();
        // GET: api/GioDatSan
        [Route("api/GioDatSan")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (var db = new Entities())
            {
                var dsGio = (from g in db.GIOs
                             select new KhungGioDatSan()
                             {
                                 MaKhungGio = g.MAKHUNGGIO,
                                 GioBatDau = g.GIOBATDAU,
                                 GioKetThuc = g.GIOKETTHUC
                             }).ToList();
                return Json(dsGio);
            }
        }
    }
}
