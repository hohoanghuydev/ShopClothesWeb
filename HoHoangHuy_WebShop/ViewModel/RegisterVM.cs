using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HoHoangHuy_WebShop.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Tên không được để trống.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "UserName không được để trống.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password không được để trống.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ComfirmPassword không được để trống.")]
        [Compare("Password", ErrorMessage = "Password và Comfirm Password không khớp.")]
        public string ComfirmPassword { get; set; }
        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Đây không phải email.")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}