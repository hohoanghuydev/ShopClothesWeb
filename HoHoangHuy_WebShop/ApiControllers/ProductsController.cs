using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HoHoangHuy_WebShop.Models;

namespace HoHoangHuy_WebShop.ApiControllers
{
    public class ProductsController : ApiController
    {
        public List<LoaiSanPham> Get()
        {
            MyDbContext db = new MyDbContext();
            List<LoaiSanPham> loai = db.LoaiSanPham.ToList();
            return loai;
        }
    }
}
