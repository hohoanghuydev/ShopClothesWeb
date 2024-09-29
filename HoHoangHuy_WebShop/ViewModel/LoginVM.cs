using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HoHoangHuy_WebShop.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Bạn chưa nhập UserName.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập Password.")]
        public string Password { get; set; }
    }
}