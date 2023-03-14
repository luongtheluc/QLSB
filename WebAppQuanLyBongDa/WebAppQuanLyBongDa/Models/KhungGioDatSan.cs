using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppQuanLyBongDa.Models
{
    public class KhungGioDatSan
    {
        public int MaKhungGio { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }
    }
}