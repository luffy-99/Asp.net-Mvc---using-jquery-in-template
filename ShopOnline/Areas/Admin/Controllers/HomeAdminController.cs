using Common;
using ShopOnline.Areas.Admin.Models;
using ShopOnline.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class HomeAdminController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var userName = (LoginViewAdmin)Session[CommonConstants.USER_SESSION];
            ViewBag.UserName = userName.UserName;
            return View();
        }
    }
}