using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppQuanLyBongDa.Models
{
    public class CacLoaiSan
    {
        public static List<CacLoaiSan> cacLoaiSans = new List<CacLoaiSan>()
        {
            new CacLoaiSan(){MaLoaiSan = 1, TenLoaiSan = "Sân cỏ tự nhiên"},
            new CacLoaiSan(){MaLoaiSan = 2, TenLoaiSan = "Sân cỏ nhân tạo"},
            new CacLoaiSan(){MaLoaiSan = 3, TenLoaiSan = "Sân hỗn hợp"}
        };
        public int MaLoaiSan { get; set; }
        public string TenLoaiSan { set; get; } 
    }
    


}