using Common;
using Service;
using ShopOnline.Infrastructure.Core;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class OrderController : BaseControllerClient
    {
        private IProductService productService;
        public OrderController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: Order
        public ActionResult Create()
        {
            var cart = Session[CommonConstants.CART_SESSION];
            var list = new List<OrderDetailView>();
            if(cart != null)
            {
                list = (List<OrderDetailView>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(int id, int quantity)
        {
            var cart = Session[CommonConstants.CART_SESSION];
            var product = productService.GetById(id);
            if (cart != null)
            {
                var list = (List<OrderDetailView>)cart;
                if(list.Exists(x=>x.ProductID == id))
                {
                    foreach(var item in list)
                    {
                        if(item.ProductID == id)
                        {
                            item.Quantitty += quantity;

                        }
                    }
                }
                else
                {
                    var item = new OrderDetailView();
                    item.Product = product;
                    item.Quantitty = quantity;
                    item.ProductID = id;
                    list.Add(item);
                }
                Session[CommonConstants.CART_SESSION] = list;
            }
            else
            {
                var item = new OrderDetailView();
                item.Product = product;
                item.ProductID = id;
                item.Quantitty = quantity;
                var list = new List<OrderDetailView>();
                list.Add(item);
                Session[CommonConstants.CART_SESSION] = list;
            }
            return RedirectToAction("Create");
        }
    }
}