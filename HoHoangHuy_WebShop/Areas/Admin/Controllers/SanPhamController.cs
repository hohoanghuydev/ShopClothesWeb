using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoHoangHuy_WebShop.Models;
using System.IO;
using HoHoangHuy_WebShop.Filters;

namespace HoHoangHuy_WebShop.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class SanPhamController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Admin/SanPham
        public ActionResult Index(string search = "", string Sort = "MaSanPham", string Icon = "", int page = 1)
        {
            List<SanPham> sanPham = db.SanPham.Where(row => row.TenSanPham.Contains(search)).ToList();
            ViewBag.Search = search;
            ViewBag.Sort = Sort;
            ViewBag.Icon = Icon;
            if (Sort == "MaSanPham")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.MaSanPham).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.MaSanPham).ToList();
            }
            else if (Sort == "TenSanPham")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.TenSanPham).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.TenSanPham).ToList();
            }
            else if (Sort == "Gia")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.Gia).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.Gia).ToList();
            }
            else if (Sort == "MaLoaiSP")
            {
                if (Icon == "fa fa-sort-down")
                    sanPham = sanPham.OrderByDescending(row => row.MaLoaiSP).ToList();
                else
                    sanPham = sanPham.OrderBy(row => row.MaLoaiSP).ToList();
            }
            int NoOfRecordPerPage = 5;
            double countFoods = sanPham.Count;

            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(countFoods) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sanPham = sanPham.Skip(NoOfSkip).Take(NoOfRecordPerPage).ToList();
            return View(sanPham);
        }
        public ActionResult Detail(int? id)
        {
            SanPham sp = db.SanPham.Where(row => row.MaSanPham == id).FirstOrDefault();
            if (sp == null)
                return RedirectToAction("Index", "SanPham", "Admin");
            return View(sp);
        }
        public ActionResult Create()
        {
            List<LoaiSanPham> loaiSP = db.LoaiSanPham.ToList();
            ViewBag.LoaiSP = loaiSP;
            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPham sp, HttpPostedFileBase fileImage)
        {
            List<LoaiSanPham> loaiSP = db.LoaiSanPham.ToList();
            ViewBag.LoaiSP = loaiSP;
            if (!ModelState.IsValid)
                return View();
            else
            {
                if(fileImage != null && fileImage.ContentLength > 0)
                {
                    if(fileImage.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Image", "Kích thước file không được lớn hơn 2MB.");
                        return View();
                    }
                    var allowExs = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(fileImage.FileName).ToLower();
                    if (!allowExs.Contains(fileEx))
                    {
                        ModelState.AddModelError("Image", "Phần mở rộng file không hỗ trợ.");
                        return View();
                    }

                    sp.HinhAnh = "";
                    db.SanPham.Add(sp);
                    db.SaveChanges();

                    SanPham sanPham = db.SanPham.ToList().Last();

                    var fileName = sanPham.MaSanPham.ToString() + fileEx;
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    fileImage.SaveAs(path);

                    sanPham.HinhAnh = fileName;
                    db.SaveChanges();
                    return RedirectToAction("Index", "SanPham", "Admin");
                }
                else
                {
                    sp.HinhAnh = "";
                    db.SanPham.Add(sp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            } 
        }
        public ActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            SanPham sp = db.SanPham.Where(row => row.MaSanPham == id).FirstOrDefault();
            List<LoaiSanPham> loaiSP = db.LoaiSanPham.ToList();
            ViewBag.LoaiSP = loaiSP;
            return View(sp);
        }
        [HttpPost]
        public ActionResult Edit(SanPham sp, HttpPostedFileBase fileImage)
        {
            List<LoaiSanPham> loaiSP = db.LoaiSanPham.ToList();
            ViewBag.LoaiSP = loaiSP;
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "SanPham", "Admin");
            else
            {
                SanPham newSP = db.SanPham.Where(row => row.MaSanPham == sp.MaSanPham).FirstOrDefault();
                newSP.MaLoaiSP = sp.MaLoaiSP;
                newSP.TenSanPham = sp.TenSanPham;
                newSP.Gia = sp.Gia;
                newSP.MoTa = sp.MoTa;
                if (fileImage != null && fileImage.ContentLength > 0)
                {
                    if (fileImage.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Image", "Kích thước file không được lớn hơn 2MB.");
                        return View();
                    }
                    var allowExs = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(fileImage.FileName).ToLower();
                    if (!allowExs.Contains(fileEx))
                    {
                        ModelState.AddModelError("Image", "Phần mở rộng file không hỗ trợ.");
                        return View();
                    }

                    var fileName = newSP.MaSanPham + fileEx;
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    fileImage.SaveAs(path);

                    newSP.HinhAnh = fileName;
                    db.SaveChanges();
                    return RedirectToAction("Index", "SanPham", "Admin");
                }
                else
                {
                    db.SaveChanges();
                    return RedirectToAction("Index", "SanPham", "Admin");
                }
            }
        }
        public ActionResult Delete(int id)
        {
            SanPham sp = db.SanPham.Where(row => row.MaSanPham == id).FirstOrDefault();
            db.SanPham.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index", "SanPham", "Admin");
        }
    }
}