using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HoHoangHuy_WebShop.Models
{
    public class DonHang
    {
        [Key]
        public int MaDonHang { get; set; }
        public int MaSanPham { get; set; }
        public string KhachHang { get; set; }
        public string KichThuoc { get; set; }
        public int SoLuong { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}đ")]
        public int TongTien { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime NgayDat { get; set; }
        public int TrangThaiThanhToan { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}