using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

using HoHoangHuy_WebShop.Identity;

[assembly: OwinStartup(typeof(HoHoangHuy_WebShop.Startup))]

namespace HoHoangHuy_WebShop
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login")
            });
            this.CreateRolesAndUsers();
        }
        public void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            var appDbContext = new AppDbContext();
            var appUserStore = new AppUserStore(appDbContext);
            var userMananger = new AppUserManager(appUserStore);
            
            if(!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if(userMananger.FindByName("admin") == null)
            {
                AppUser user = new AppUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                string userPw = "admin123";

                var chkUser = userMananger.Create(user, userPw);
                if (chkUser.Succeeded)
                {
                    userMananger.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}
