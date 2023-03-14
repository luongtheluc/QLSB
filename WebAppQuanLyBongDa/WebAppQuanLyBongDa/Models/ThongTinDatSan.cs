using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppQuanLyBongDa.Models
{
    public class ThongTinDatSan
    {
        public int tenKh { get; set; }
        public DateTime ngaydat { get; set; }
        public DateTime giodat { get; set; }
        public string tenDv { get; set; }
        public int manv { get; set; }
        public string tensan { get; set; }
        public int maptt { get; set; }
        public int gio { get; set; }
        public int madv { get; set; }
        public int soLanSuDung { get; set; }
        public int tongTien { get; set; }
    }
}