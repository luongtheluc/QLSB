using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppQuanLyBongDa.Models
{
    public class ChiTietDatSan
    {
        public int MaSan { get; set; }
        public string TenSan { get; set; }
        public DateTime NgayDatSan { get; set; }
        public DateTime GioDatSan { get; set; }
        public string TrangThaiSan { get; set; }
    }
}