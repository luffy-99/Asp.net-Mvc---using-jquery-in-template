using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Models
{
    public class UserViewAdmin
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string UserName { set; get; }
        public string PassWord { set; get; }
        public string Position { set; get; }
    }
}