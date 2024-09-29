using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoHoangHuy_WebShop.Models;

namespace HoHoangHuy_WebShop.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Home
        public ActionResult Index()
        {
            List<SanPham> sanPham = db.SanPham.ToList();
            return View(sanPham);
        }
        public ActionResult Error404()
        {
            return View();
        }
    }
}