using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebAppQuanLyBongDa.Models;

namespace WebAppQuanLyBongDa.Controllers
{
    [RoutePrefix("cacloaiSans")]
    public class CacLoaiSanController : ApiController
    {
        // GET: api/CacLoaiSan
        public IEnumerable<CacLoaiSan> Get()
        {
            return CacLoaiSan.cacLoaiSans;
        }

        // GET: api/CacLoaiSan/1
        [Route("{MaLoaiSan}")]
        public object Get(int MaLoaiSan)
        {
            var cacloaisan = CacLoaiSan.cacLoaiSans.Where(e => e.MaLoaiSan == MaLoaiSan).FirstOrDefault();
            return cacloaisan;
        }

        // POST: api/CacLoaiSan
        [Route("")]
        public bool Post([FromBody] CacLoaiSan cacloaisan)
        {
            CacLoaiSan.cacLoaiSans.Add(cacloaisan);
            return true;
        }

        // PUT: api/CacLoaiSan/5
        [Route("")]
        public bool Put(int id, [FromBody] CacLoaiSan cacloaisan)
        {
            //Xác định loại sân cần chỉnh sửa trong danh sách các loại sân
            var cacloaisanEdit = CacLoaiSan.cacLoaiSans.Where(e => e.MaLoaiSan == cacloaisan.MaLoaiSan).FirstOrDefault();
            CacLoaiSan.cacLoaiSans.Remove(cacloaisanEdit);
            CacLoaiSan.cacLoaiSans.Add(cacloaisanEdit);
            return true;

        }

        // DELETE: api/CacLoaiSan/1
        [Route("{MaLoaiSan}")]
        public bool Delete(int MaLoaiSan)
        {
            var result = false;
            //Xác định loại sân cần xóa trong danh sách các loại sân
            var cacloaisanEdit = CacLoaiSan.cacLoaiSans.Where(e => e.MaLoaiSan == MaLoaiSan).FirstOrDefault();
            if (cacloaisanEdit != null)
            {
                CacLoaiSan.cacLoaiSans.Remove(cacloaisanEdit);
                result = true;
            }
            return result;
        }
    }
}
