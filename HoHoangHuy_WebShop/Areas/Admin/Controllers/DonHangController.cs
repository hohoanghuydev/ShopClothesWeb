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
    public class DonHangController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Admin/DonHang
        public ActionResult Index()
        {
            List<DonHang> donHang = db.DonHang.ToList();
            return View(donHang);
        }
    }
}