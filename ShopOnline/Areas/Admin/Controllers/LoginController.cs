
using Common;
using Service;
using ShopOnline.Areas.Admin.Models;
using ShopOnline.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private IUserService userService;
        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: Admin/Login
        public ActionResult Login(LoginViewAdmin loginViewAdmin)
        {
            var isBool = userService.GetUser(loginViewAdmin.UserName,loginViewAdmin.PassWord);
            if (isBool)
            {
                var userSession = new LoginViewAdmin();
                var userEntity = userService.GetUserByName(loginViewAdmin.UserName);
                userSession.ID = userEntity.ID;
                userSession.UserName = userEntity.UserName;
                Session.Add(CommonConstants.USER_SESSION, userSession);
                return RedirectToAction("Index", "HomeAdmin");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không đúng!");
            }
            return View();
        }
    }
}