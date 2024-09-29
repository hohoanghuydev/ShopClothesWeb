using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HoHoangHuy_WebShop.CustomValidation
{
    public class DivideBy1000 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double gia = Convert.ToDouble(value);
            if (gia % 1000 == 0)
                return ValidationResult.Success;
            else
                return new ValidationResult(this.ErrorMessage);
        }
    }
}