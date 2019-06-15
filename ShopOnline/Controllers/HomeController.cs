using Models;
using Service;
using ShopOnline.Mapping;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class HomeController : Controller
    {
        private IMenuGroupService menuGroupService;
        private IProductService productService;
        private IProductCategoryService productCategoryService;
        public HomeController(IMenuGroupService menuGroupService, IProductService productService, IProductCategoryService productCategoryService)
        {
            this.menuGroupService = menuGroupService;
            this.productService = productService;
            this.productCategoryService = productCategoryService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public ActionResult _Menu()
        {
            var menuEntity = menuGroupService.GetAll();
            var menuView = AutoMapperConfiguration.Mapping.Map<IEnumerable<MenuGroup>, IEnumerable<MenuGroupView>>(menuEntity);
            ViewBag.Products = productService.GetAll();
            return PartialView(menuView);
        }
        [ChildActionOnly]
        public ActionResult _Category()
        {
            var categoryEntity = productCategoryService.GetAll();
            var categoryView = AutoMapperConfiguration.Mapping.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryView>>(categoryEntity);
            return PartialView(categoryView);
        }
        [ChildActionOnly]
        public ActionResult _Footer()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Cart()
        {
            return PartialView();
        }
    }
}