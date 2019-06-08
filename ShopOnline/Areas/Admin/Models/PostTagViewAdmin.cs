using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Models
{
    public class PostTagViewAdmin
    {
        public int PostID { set; get; }

        public string TagID { set; get; }

        public virtual PostViewAdmin Post { set; get; }

        public virtual TagViewAdmin Tag { set; get; }
    }
}