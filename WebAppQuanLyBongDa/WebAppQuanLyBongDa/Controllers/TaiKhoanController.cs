using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppQuanLyBongDa.Models;
using WebAppQuanLyBongDa.Libs;

namespace WebAppQuanLyBongDa.Controllers
{
    public class TaiKhoanController : ApiController
    {
        Entities db = new Entities();     

        // Get tất cả
       
        // GET: api/DichVu
        [Route("api/TaiKhoan")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (var db = new Entities())
            {
                var dsTaiKhoan = (from tk in db.TAIKHOANs
                                select new ThongTinTaiKhoan()
                                {
                                    MaTaiKhoan = tk.MATK,
                                    TenTaiKhoan = tk.TENTK,
                                    MatKhau = tk.MATKHAU,
                                    TenHienThi = tk.TENHIENTHI,
                                    ChucVu = tk.VAITRO
                                }).ToList();
                return Json(dsTaiKhoan);
            }
        }

        // Post
        [Route("api/TaiKhoan")]
        [HttpPost]
        public IHttpActionResult Post(DangKyTaiKhoan dk)
        {
            var tk = new TAIKHOAN();
            var kh = new KHACHHANG();
            tk.TENTK = dk.TenTaiKhoan;
            tk.MATKHAU = Encrypt.MaHoaMD5(dk.MatKhau);
            tk.TENHIENTHI = dk.TenHienThi;
            tk.VAITRO = "Khách hàng";
            var themTK = Them(tk);

            kh.TENKH = tk.TENHIENTHI;
            kh.SDTKH = dk.SoDienThoai;
            kh.DIACHIKH = dk.DiaChi;
            kh.MATK = themTK;
            db.KHACHHANGs.Add(kh);
            db.SaveChanges();
            return Json(dk);
        }

        public int Them(TAIKHOAN tk)
        {
            db.TAIKHOANs.Add(tk);
            db.SaveChanges();
            return tk.MATK;
        }
    }
}
