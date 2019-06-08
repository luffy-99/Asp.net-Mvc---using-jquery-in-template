using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Models
{
    public class LoginViewAdmin
    {
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập!")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu!")]
        public string PassWord { set; get; }
    }
}