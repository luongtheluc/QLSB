using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppQuanLyBongDa.Models
{
    public class ThongTinTaiKhoan
    {
        public int MaTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string TenHienThi { get; set; }
        public string ChucVu { get; set; }
    }
}