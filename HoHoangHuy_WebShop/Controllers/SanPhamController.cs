using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoHoangHuy_WebShop.Models;

namespace HoHoangHuy_WebShop.Controllers
{
    public class SanPhamController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: SanPham
        public ActionResult Index(string search = "", string Sort = "TenSanPham", string Icon = "", int page = 1)
        {
            List<SanPham> sanPham = db.SanPham.Where(row => row.TenSanPham.Contains(search)).ToList();
            ViewBag.Search = search;
            ViewBag.Sort = Sort;
            ViewBag.Icon = Icon;
            if (Sort == "TenSanPham")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.TenSanPham).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.TenSanPham).ToList();
            }
            if (Sort == "Gia")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.Gia).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.Gia).ToList();
            }
            if(Sort == "Loai")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.MaLoaiSP).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.MaLoaiSP).ToList();
            }    
            int NoOfRecordPerPage = 8;
            double countProducts = sanPham.Count;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(countProducts) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sanPham = sanPham.Skip(NoOfSkip).Take(NoOfRecordPerPage).ToList();
            return View(sanPham);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            else
            {
                SanPham sp = db.SanPham.Where(row => row.MaSanPham == id).FirstOrDefault();
                return View(sp);
            }
        }
        public ActionResult T_Shirt(string Sort = "TenSanPham", string Icon = "", int page = 1)
        {
            List<SanPham> sanPham = db.SanPham.Where(row => row.MaLoaiSP == 1).ToList();
            ViewBag.Sort = Sort;
            ViewBag.Icon = Icon;
            if (Sort == "TenSanPham")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.TenSanPham).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.TenSanPham).ToList();
            }
            if (Sort == "Gia")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.Gia).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.Gia).ToList();
            }
            if (Sort == "Loai")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.MaLoaiSP).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.MaLoaiSP).ToList();
            }
            int NoOfRecordPerPage = 8;
            double countProducts = sanPham.Count;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(countProducts) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sanPham = sanPham.Skip(NoOfSkip).Take(NoOfRecordPerPage).ToList();
            return View(sanPham);
        }
        public ActionResult Shirt(string Sort = "TenSanPham", string Icon = "", int page = 1)
        {
            List<SanPham> sanPham = db.SanPham.Where(row => row.MaLoaiSP == 2).ToList();
            ViewBag.Sort = Sort;
            ViewBag.Icon = Icon;
            if (Sort == "TenSanPham")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.TenSanPham).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.TenSanPham).ToList();
            }
            if (Sort == "Gia")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.Gia).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.Gia).ToList();
            }
            if (Sort == "Loai")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.MaLoaiSP).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.MaLoaiSP).ToList();
            }
            int NoOfRecordPerPage = 8;
            double countProducts = sanPham.Count;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(countProducts) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sanPham = sanPham.Skip(NoOfSkip).Take(NoOfRecordPerPage).ToList();
            return View(sanPham);
        }
        public ActionResult Polo(string Sort = "TenSanPham", string Icon = "", int page = 1)
        {
            List<SanPham> sanPham = db.SanPham.Where(row => row.MaLoaiSP == 3).ToList();
            ViewBag.Sort = Sort;
            ViewBag.Icon = Icon;
            if (Sort == "TenSanPham")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.TenSanPham).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.TenSanPham).ToList();
            }
            if (Sort == "Gia")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.Gia).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.Gia).ToList();
            }
            if (Sort == "Loai")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.MaLoaiSP).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.MaLoaiSP).ToList();
            }
            int NoOfRecordPerPage = 8;
            double countProducts = sanPham.Count;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(countProducts) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sanPham = sanPham.Skip(NoOfSkip).Take(NoOfRecordPerPage).ToList();
            return View(sanPham);
        }
    }
}