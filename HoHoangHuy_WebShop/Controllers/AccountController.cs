using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoHoangHuy_WebShop.ViewModel;
using HoHoangHuy_WebShop.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Helpers;
using HoHoangHuy_WebShop.Filters;

namespace HoHoangHuy_WebShop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index(string id)
        {
            if (id == null) return RedirectToAction("Index", "Home");
            AppDbContext db = new AppDbContext();
            AppUser user = db.Users.Where(row => row.UserName == id).FirstOrDefault();
            return View(user);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM registerVM)
        {
            if(ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
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
                if(result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            if(ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var user = userManager.Find(loginVM.UserName, loginVM.Password);
                if (user != null)
                {
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                    if(userManager.IsInRole(user.Id, "Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("myError", "Invalid username and password.");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
        }
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}