using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoHoangHuy_WebShop.Filters;
using HoHoangHuy_WebShop.Identity;
using HoHoangHuy_WebShop.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Helpers;

namespace HoHoangHuy_WebShop.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class AccountController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Admin/Account
        public ActionResult Index()
        {
            List<AppUser> user = db.Users.ToList();
            return View(user);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var userStore = new AppUserStore(db);
                var userManager = new AppUserManager(userStore);
                var passwordHash = Crypto.HashPassword(registerVM.Password);
                var user = new AppUser()
                {
                    Name = registerVM.Name,
                    Email = registerVM.Email,
                    UserName = registerVM.UserName,
                    PasswordHash = passwordHash,
                    NgaySinh = registerVM.DateOfBirth,
                    Address = registerVM.Address,
                    PhoneNumber = registerVM.PhoneNumber
                };
                IdentityResult result = userManager.Create(user);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    return RedirectToAction("Index", "Account", new { area = "Admin" });
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
        }
        public ActionResult Edit(string id)
        {
            if (id == null) return RedirectToAction("Index", "Account", new { area = "Admin" });
            AppUser user = db.Users.Where(row => row.Id == id).FirstOrDefault();
            ViewBag.Id = id;
            return View(user);//View là RegisterVM
        }
        [HttpPost]
        public ActionResult Edit(RegisterVM registerVM, string Id)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = Crypto.HashPassword(registerVM.Password);
                AppUser user = db.Users.Where(row => row.Id == Id).FirstOrDefault();
                user.Name = registerVM.Name;
                user.UserName = registerVM.UserName;
                user.PasswordHash = passwordHash;
                user.Email = registerVM.Email;
                user.PhoneNumber = registerVM.PhoneNumber;
                user.NgaySinh = registerVM.DateOfBirth;
                user.Address = registerVM.Address;
                db.SaveChanges();
                return RedirectToAction("Index", "Account", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
        }
        public ActionResult Delete(string id)
        {
            AppUser user = db.Users.Where(row => row.Id == id).FirstOrDefault();
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Account", new { area = "Admin" });
        }
    }
}