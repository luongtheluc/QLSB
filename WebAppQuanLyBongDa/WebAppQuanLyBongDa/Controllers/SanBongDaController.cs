using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebAppQuanLyBongDa.Models;
using System.Net.Http;
using System.Web.Http;


namespace WebAppQuanLyBongDa.Controllers
{
    public class SanBongDaController : ApiController
    {
        Entities db = new Entities();
        // GET: api/SanBongDa
        [Route("api/SanBongDa")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (var db = new Entities())
            {
                var dsSan = (from sb in db.SANs
                             select new SanBongDa()
                             {
                                 MaSan = sb.MASAN,
                                 TenSan = sb.TENSAN,
                                 TrangThai = sb.TRANGTHAI,
                                 MaLoaiSan = sb.MALOAISAN
                             }).ToList();
                return Json(dsSan);
            }
        }

        [Route("api/SanBongDa")]
        [HttpPost]
        public string Post(SAN sb)
        {
            db.SANs.Add(sb);
            db.SaveChanges();
            return "Đã thêm sân";
        }

        /*
        // PUT: SanBongDa/1
        [HttpPut]
        public bool Put( [FromBody] SanBongDa sanbongda)
        {
            //Xác định sân cần chỉnh sửa trong danh sách các sân
            var sanbongdaEdit = SanBongDa.sanbongdas.Where(e => e.MaSan == sanbongda.MaSan).FirstOrDefault();
            SanBongDa.sanbongdas.Remove(sanbongdaEdit);
            SanBongDa.sanbongdas.Add(sanbongda);
            return true;

        }

        // DELETE: api/SanBongDa/1
        public bool Delete(int MaSan)
        {
            var result = false;
            //Xác định sân cần xóa trong danh sách các sân
            var sanbongdaEdit = SanBongDa.sanbongdas.Where(e => e.MaSan == MaSan).FirstOrDefault();
            if(sanbongdaEdit != null)
            {
                SanBongDa.sanbongdas.Remove(sanbongdaEdit);
                result = true;
            }
            return result;
        }
        */
    }
}
