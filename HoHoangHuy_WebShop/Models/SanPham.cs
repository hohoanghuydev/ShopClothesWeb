using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HoHoangHuy_WebShop.CustomValidation;

namespace HoHoangHuy_WebShop.Models
{
    public class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
        [RegularExpression("^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ0-9 ]*$", ErrorMessage = "Tên sản phẩm không được chứa ký tự đặc biệt.")]
        public string TenSanPham { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:N0}đ")]
        [Required(ErrorMessage = "Giá không được để trống.")]
        [DivideBy1000(ErrorMessage = "Giá sản phẩm phải chia hết cho 1000đ")]
        public int Gia { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống.")]
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        [Required(ErrorMessage = "Loại sản phẩm không được để trống.")]
        public int MaLoaiSP { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}