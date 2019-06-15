using Models;
using ShopOnline.Areas.Admin.Models;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Infrastructure.Extension
{
    public static class EntityExtensions
    {
        public static void UpdateProduct(this Product product, ProductViewAdmin productVm)
        {
            product.ID = productVm.ID;
            product.Name = productVm.Name;
            product.Description = productVm.Description;
            product.Alias = productVm.Alias;
            product.CategoryID = productVm.CategoryID;
            product.Content = productVm.Content;
            product.Image = productVm.Image;
            product.MoreImages = productVm.MoreImages;
            product.Price = productVm.Price;
            product.PromotionPrice = productVm.PromotionPrice;
            product.Warranty = productVm.Warranty;
            product.HomeFlag = productVm.HomeFlag;
            product.HotFlag = productVm.HotFlag;
            product.ViewCount = productVm.ViewCount;

            product.CreatedDate = productVm.CreatedDate;
            product.CreatedBy = productVm.CreatedBy;
            product.UpdatedDate = productVm.UpdatedDate;
            product.UpdatedBy = productVm.UpdatedBy;
            product.MetaKeyword = productVm.MetaKeyword;
            product.MetaDescription = productVm.MetaDescription;
            product.Status = productVm.Status;
            product.Tags = productVm.Tags;
            product.Quantity = productVm.Quantity;
        }
        public static void UpdateUser(this User user, UserViewAdmin userView)
        {
            user.ID = userView.ID;
            user.Name = userView.Name;
            user.UserName = userView.UserName;
            user.PassWord = userView.PassWord;
            user.Position = userView.Position;
        }
        public static void UpdateUserClient(this User user, UserView userView)
        {
            user.Name = userView.Name;
            user.UserName = userView.UserName;
            user.PassWord = userView.PassWord;
            user.Position = "Client";
        }
        public static void UpdateProducToView(this ProductView productView, Product product)
        {
            productView.ID = product.ID;
            productView.Name = product.Name;
            productView.Alias = product.Alias;
            productView.CategoryID = product.CategoryID;
            productView.Image = product.Image;
            productView.MoreImages = product.MoreImages;
            productView.Price = product.Price;
            productView.PromotionPrice = product.PromotionPrice;
            productView.Warranty = product.Warranty;
            productView.Description = product.Description;
            productView.Content = product.Content;
            productView.CreatedDate = product.CreatedDate;
            productView.UpdatedDate = product.UpdatedDate;
            productView.ViewCount = product.ViewCount;
            productView.MetaDescription = product.MetaDescription;
            productView.MetaKeyword = product.MetaKeyword;
            productView.Tags = product.Tags;
            productView.Quantity = product.Quantity;
        }
    }
}