using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoHoangHuy_WebShop.Models;
using HoHoangHuy_WebShop.Filters;

namespace HoHoangHuy_WebShop.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class LoaiSanPhamController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Admin/LoaiSanPham
        public ActionResult Index()
        {
            List<LoaiSanPham> loai = db.LoaiSanPham.ToList();
            return View(loai);
        }
    }
}