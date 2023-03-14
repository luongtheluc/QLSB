using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppQuanLyBongDa.Models;

namespace WebAppQuanLyBongDa.Controllers
{
    public class DichVuSanController : ApiController
    {
        Entities db = new Entities();
        // GET: api/DichVu
        [Route("api/DichVu")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (var db = new Entities())
            {
                var dsDichVu = (from dv in db.DICHVUs
                                select new DichVuSan()
                                {
                                    MaDichVu = dv.MADICHVU,
                                    TenDichVu = dv.TENDICHVU,
                                    GiaTien = dv.GIATIEN
                                }).ToList();
                return Json(dsDichVu);
            }
        }
    }
}
