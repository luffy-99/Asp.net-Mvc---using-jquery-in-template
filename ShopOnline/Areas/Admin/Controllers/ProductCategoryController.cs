using Models;
using Service;
using ShopOnline.Areas.Admin.Models;
using ShopOnline.Infrastructure.Core;
using ShopOnline.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        private IProductCategoryService productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }
        // GET: Admin/ProductCategory
        public ActionResult GetAllCategory()
        {
            var categoryEntity = productCategoryService.GetAll();
            var categoryView = AutoMapperConfiguration.Mapping.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewAdmin>>(categoryEntity);
            return View(categoryView);
        }
    }
}