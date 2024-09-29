using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HoHoangHuy_WebShop.Models
{
    public class LoaiSanPham
    {
        [Key]
        public int MaLoaiSP { get; set; }
        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống!")]
        public string TenLoaiSP { get; set; }
    }
}