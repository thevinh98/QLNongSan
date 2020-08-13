using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNS.Models.Function
{
    public class LoginModels
    {
        [Display(Name = "Nhập UserName:")]
        [Required(ErrorMessage = "Mời bạn nhập UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập PassWord")]

        [Display(Name = "Nhập PassWord:")]

        public string PassWord { get; set; }

        public bool Remmember { get; set; }
    }
}