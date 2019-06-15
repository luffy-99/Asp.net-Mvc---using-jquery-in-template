using Common;
using Models;
using PagedList;
using Service;
using ShopOnline.Areas.Admin.Models;
using ShopOnline.Infrastructure.Core;
using ShopOnline.Infrastructure.Extension;
using ShopOnline.Mapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;
        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
        }
        public string UploadFile(HttpPostedFileBase file)
        {
            string path = "";
            if (file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string folderPath = Path.Combine(Server.MapPath("/Data/images/"), fileName);
                file.SaveAs(folderPath);
                path += folderPath;

            }
            return path;
        }
        // GET: Admin/Product
        public ActionResult GetAllProduct(int page=1, int pageSize=3)
        {
            var productEntity = _productService.GetAll();
            IEnumerable<ProductViewAdmin> productView = AutoMapperConfiguration.Mapping.Map<IEnumerable<Product>, IEnumerable<ProductViewAdmin>>(productEntity);
            string[] Category = new string[_productCategoryService.GetAll().Count()+1];
            foreach (var product in productView)
            {
                
                Category[product.CategoryID] = _productCategoryService.GetById(product.CategoryID).Name;
                
                if (product.Description.Length > 20)
                {
                    product.Description = product.Description.Substring(0, 20) + " ...";
                }
            }
            ViewBag.categoryName = Category;
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
            SetViewProductCategory();
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