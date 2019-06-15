using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class ProductView
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string Alias { set; get; }

        public int CategoryID { set; get; }

        public string Image { set; get; }

        public string MoreImages { set; get; }

        public decimal Price { set; get; }

        public decimal? PromotionPrice { set; get; }

        public int? Warranty { set; get; }

        public string Description { set; get; }

        public string Content { set; get; }

        public int? ViewCount { set; get; }

        public DateTime? CreatedDate { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }

        public string Tags { set; get; }

        public int Quantity { set; get; }

        
        public virtual ProductCategoryView ProductCategory { set; get; }
    }
}