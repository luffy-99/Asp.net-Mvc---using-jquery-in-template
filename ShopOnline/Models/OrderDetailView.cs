using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class OrderDetailView
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        public int Quantitty { get; set; }
        public decimal Price { set; get; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}