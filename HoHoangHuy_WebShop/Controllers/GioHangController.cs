using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoHoangHuy_WebShop.Models;
using HoHoangHuy_WebShop.Filters;

namespace HoHoangHuy_WebShop.Controllers
{
    [AuthenticationFilter]
    public class GioHangController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: GioHang
        public ActionResult Index()
        {
            List<DonHang> donHang = db.DonHang.Where(row => row.TrangThaiThanhToan == 0).ToList();
            ViewBag.tongTien = donHang.Sum(row => row.TongTien);
            return View(donHang);
        }
        public ActionResult AddToCart(int id = 0, string kichThuoc = "L", int soLuong = 1)
        {
            if(id > 0)
            {
                DonHang donHang = db.DonHang.Where(row => row.MaSanPham == id && row.KichThuoc == kichThuoc && row.TrangThaiThanhToan == 0).FirstOrDefault();
                if(donHang != null )
                {
                    donHang.NgayDat = DateTime.Now.Date;
                    donHang.SoLuong += soLuong;
                    donHang.TongTien = donHang.SanPham.Gia * donHang.SoLuong;
                }    
                else
                {
                    DonHang donHangNew = new DonHang();
                    SanPham sp = db.SanPham.Where(row => row.MaSanPham == id).FirstOrDefault();
                    donHangNew.MaSanPham = id;
                    donHangNew.NgayDat = DateTime.Now.Date;
                    donHangNew.SoLuong = soLuong;
                    donHangNew.KichThuoc = kichThuoc;
                    donHangNew.TongTien = sp.Gia * donHangNew.SoLuong;
                    donHangNew.TrangThaiThanhToan = 0;
                    db.DonHang.Add(donHangNew);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult ThanhToan()
        {
            List<DonHang> donHang = db.DonHang.Where(row => row.TrangThaiThanhToan == 0).ToList();
            foreach(DonHang dh in donHang)
            {
                dh.TrangThaiThanhToan = 1;
            }
            db.SaveChanges();
            return View();
        }
    }
}