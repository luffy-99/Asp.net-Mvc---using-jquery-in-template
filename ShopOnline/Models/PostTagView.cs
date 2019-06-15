using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class PostTagView
    {
        public int PostID { set; get; }

        public string TagID { set; get; }

        public virtual PostView Post { set; get; }

        public virtual TagView Tag { set; get; }
    }
}