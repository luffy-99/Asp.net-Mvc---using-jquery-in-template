using Models;
using PagedList;
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
    public class ProductsController : Controller
    {
        private IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: Product
        [ChildActionOnly]
        public ActionResult DealsOfTheDay()
        {
            var productEntity = productService.DealsProduct();
            var productView = AutoMapperConfiguration.Mapping.Map<IEnumerable<Product>,IEnumerable<ProductView>>(productEntity);
            int[] saleDeal = new int[1000];
            foreach(var product in productView)
            {
                saleDeal[product.ID] = Convert.ToInt32(((product.Price - product.PromotionPrice) / product.Price) * 100);
            }
            ViewBag.saleDeal = saleDeal;
            return PartialView(productView);
        }
        [ChildActionOnly]
        public ActionResult LatestProduct()
        {
            var productEntity = productService.LatestProduct();
            var productView = AutoMapperConfiguration.Mapping.Map<IEnumerable<Product>, IEnumerable<ProductView>>(productEntity);
            int[] saleLatest = new int[1000];
            foreach (var product in productView)
            {
                saleLatest[product.ID] = Convert.ToInt32(((product.Price - product.PromotionPrice) / product.Price) * 100);
            }
            ViewBag.saleLatest = saleLatest;
            return PartialView(productView);
        }
        [ChildActionOnly]
        public ActionResult PickedForYou()
        {
            var productEntity = productService.PickForYou();
            var productView = AutoMapperConfiguration.Mapping.Map<IEnumerable<Product>, IEnumerable<ProductView>>(productEntity);
            int[] salePick = new int[1000];
            foreach (var product in productView)
            {
                salePick[product.ID] = Convert.ToInt32(((product.Price - product.PromotionPrice) / product.Price) * 100);
            }
            ViewBag.salePick = salePick;
            return PartialView(productView);
        }
        [HttpGet]
        public ActionResult GetProducts(int id, int page=1, int pageSize = 1)
        {
            var productEntity = productService.GetByCategory(id); 
            var productView = AutoMapperConfiguration.Mapping.Map<IEnumerable<Product>, IEnumerable<ProductView>>(productEntity);
            int[] sale = new int[1000];
            foreach (var product in productView)
            {
                sale[product.ID] = Convert.ToInt32(((product.Price - product.PromotionPrice) / product.Price) * 100);
            }
            ViewBag.sale = sale;
            return View(productView.ToPagedList(page, pageSize));
        }
        [HttpGet]
        public ActionResult ProductDetail(int id)
        {
            var productEntity = productService.GetById(id);
            var productView = AutoMapperConfiguration.Mapping.Map<Product, ProductView>(productEntity);
            if(productView.PromotionPrice > 0)
            {
                ViewBag.saleDetail = Convert.ToInt32(((productView.Price - productView.PromotionPrice) / productView.Price) * 100);
            }
            return View(productView);
        }
    }
}