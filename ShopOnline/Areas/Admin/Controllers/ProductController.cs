using Models;
using PagedList;
using Service;
using ShopOnline.Areas.Admin.Models;
using ShopOnline.Infrastructure.Extension;
using ShopOnline.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;
        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
        }
        // GET: Admin/Product
        public ActionResult GetAllProduct(int page=1, int pageSize=3)
        {
            var productEntity = _productService.GetAll();
            IEnumerable<ProductViewAdmin> productView = AutoMapperConfiguration.Mapping.Map<IEnumerable<Product>, IEnumerable<ProductViewAdmin>>(productEntity);
            foreach(var product in productView)
            {
                if (product.Description.Length > 20)
                {
                    product.Description = product.Description.Substring(0, 20) + " ...";
                }
            }
            return View(productView.ToPagedList(page, pageSize));
        }
        public void SetViewProductCategory(int? selectedId = null)
        {
            ViewBag.CategoryID = new SelectList(_productCategoryService.GetAll().ToList(), "ID", "Name", selectedId);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            SetViewProductCategory();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductViewAdmin productView)
        {
            Product productEntity = new Product();
            productEntity.UpdateProduct(productView);
            var result = _productService.Add(productEntity);
            _productService.Save();
            if(result.ID > 0)
            {
                return RedirectToAction("GetAllProduct", "Product");
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var productEntity = _productService.GetById(id);
            ProductViewAdmin productView = AutoMapperConfiguration.Mapping.Map<Product, ProductViewAdmin>(productEntity);
            return View(productView);
        }
        [HttpPost]
        public ActionResult UpdateProduct(ProductViewAdmin productView)
        {
            Product productEntity = new Product();
            productEntity.UpdateProduct(productView);
            _productService.Update(productEntity);
            _productService.Save();
            return RedirectToAction("GetAllProduct", "Product");
        }
        public ActionResult DeleteProduct(int id)
        {
            var result = _productService.Delete(id);
            _productService.Save();
            if(result.ID > 0)
            {
                return RedirectToAction("GetAllProduct", "Product");
            }
            return View();
        }

    }
}