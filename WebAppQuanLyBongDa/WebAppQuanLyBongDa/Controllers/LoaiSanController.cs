using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppQuanLyBongDa.Models;

namespace WebAppQuanLyBongDa.Controllers
{
    public class LoaiSanController : ApiController
    {
        private Entities db = new Entities();

        // Post
        public string Post(LOAISAN ls)
        {
            db.LOAISANs.Add(ls);
            db.SaveChanges();
            return "Đã thêm loại sân";
        }

        // Get tất cả
        public IEnumerable<LOAISAN> Get()
        {
            return db.LOAISANs.ToList();
        }
    }
}
