using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HoHoangHuy_WebShop.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyConnection") { }
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<DonHang> DonHang { get; set; }
    }
}