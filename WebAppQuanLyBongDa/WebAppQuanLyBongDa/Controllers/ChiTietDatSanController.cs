using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppQuanLyBongDa.Models;

namespace WebAppQuanLyBongDa.Controllers
{
    public class ChiTietDatSanController : ApiController
    {
        Entities db = new Entities();

        //Get

        [HttpGet]
        [Route("api/ChiTietDatSan")]
        public IHttpActionResult Get()
        {
            using (var db = new Entities())
            {
                var test = (from sb in db.CHITIET_PHIEUDATSAN
                            select new ChiTietDatSan()
                            {
                                MaSan = sb.MASAN,
                                TenSan = sb.SAN.TENSAN,
                                NgayDatSan = sb.PHIEUDATSAN.NGAYDATSAN,
                                GioDatSan = sb.PHIEUDATSAN.GIODATSAN,
                                TrangThaiSan = sb.SAN.TRANGTHAI
                            }).ToList();

                return Json(test);
            }
        }
      
        [Route("api/ChiTietDatSan")]
        [HttpPost]
        public IHttpActionResult Post(ThongTinDatSan ct)
        {
            var san = new SAN();
            var pds = new PHIEUDATSAN();
            var ctPds = new CHITIET_PHIEUDATSAN();
            var ttSan = new TINHTRANGSAN();
            var dv = new DICHVU();
            var ctDV = new CHITIET_DICHVU();
            var ptt = new PHIEUTHANHTOAN();

            pds.NGAYDATSAN = ct.ngaydat;
            pds.GIODATSAN = ct.giodat;
            pds.NGAYLAPPDS = DateTime.Today;
            pds.MAKH = ct.tenKh;
            pds.MANV = 1;
            var maPDS = Them(pds);

            ctPds.MAPDS = maPDS;
            ctPds.MASAN = getMaSan(ct.tensan);
            ctPds.MAPTT = ptt.MAPTT;
            //ctPds.MAKHUNGGIO = ct.gio;
            ctPds.MADICHVU = getMaDV(ct.tenDv);
            db.CHITIET_PHIEUDATSAN.Add(ctPds);
                  
            var maTT = CapNhatSan(ttSan);

            ptt.NGAYLAPPTT = DateTime.Today;
            ptt.TONGTIEN = 150000 + (getDichVu(ctDV.MADICHVU) * ct.soLanSuDung);
            ptt.MANV = 1;
            var maPTT = ThemPTT(ptt);

            ctDV.MADICHVU = (int)ctPds.MADICHVU;
            ctDV.MAPTT = maPTT;
            ctDV.SOLANSUDUNG = ct.soLanSuDung;
            db.CHITIET_DICHVU.Add(ctDV);

            db.SaveChanges();
            return Ok(ct);
        }

        public int Them(PHIEUDATSAN pds)
        {
            db.PHIEUDATSANs.Add(pds);
            db.SaveChanges();
            return pds.MAPDS;
        }

        public int ThemTinhTrangSan(TINHTRANGSAN tt)
        {
            db.TINHTRANGSANs.Add(tt);
            db.SaveChanges();
            return tt.MATINHTRANGSAN;
        }

        public bool CapNhatSan(TINHTRANGSAN tts)
        {
            using(var db = new Entities())
            {
                SAN s = new SAN();
                GIO g = new GIO();
                CHITIET_PHIEUDATSAN ct = new CHITIET_PHIEUDATSAN();
                if(s.MASAN == ct.MASAN && g.MAKHUNGGIO == ct.MAKHUNGGIO)
                {
                    if (ct.MASAN == tts.MASAN && ct.MAKHUNGGIO == tts.MAKHUNGGIO)
                    {
                        tts.TRANGTHAI = 1;
                        db.SaveChanges();
                        return true;
                    }
                }              
                else
                {
                    return false;
                }
            }
            return true;
        }

        public int ThemPTT(PHIEUTHANHTOAN ptt)
        {
            db.PHIEUTHANHTOANs.Add(ptt);
            db.SaveChanges();
            return ptt.MAPTT;
        }

        public int getMaSan(string tenSan)
        {
            var masan = db.SANs.Where(i => i.TENSAN == tenSan).FirstOrDefault().MASAN;
            return masan;
        }

        public int getMaDV(string tenDV)
        {
            var maDV = db.DICHVUs.Where(i => i.TENDICHVU == tenDV).FirstOrDefault().MADICHVU;
            return maDV;
        }

        public int getMaKH(int maKhachHang)
        {
            var maKH = db.KHACHHANGs.Where(i => i.MAKH == maKhachHang).FirstOrDefault();
            return maKhachHang;
        }

        public int getDichVu(int giaTien)
        {
            var tienDV = db.DICHVUs.Where(i => i.GIATIEN == giaTien).FirstOrDefault();
            return tienDV.MADICHVU;
        }
    }
}
