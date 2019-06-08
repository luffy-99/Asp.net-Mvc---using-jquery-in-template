using Service;
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
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        // GET: Admin/Product
        public ActionResult GeAll()
        {
            var listproduct = _productService.GeAll();
            return View(listproduct);
        }
    }
}