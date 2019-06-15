using Common;
using Models;
using Service;
using ShopOnline.Areas.Admin.Models;
using ShopOnline.Infrastructure.Extension;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
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
            var isBool = userService.GetUser(loginViewAdmin.UserName, loginViewAdmin.PassWord);
            if (isBool)
            {
                var userSession = new LoginViewAdmin();
                var userEntity = userService.GetUserByName(loginViewAdmin.UserName);
                userSession.ID = userEntity.ID;
                userSession.UserName = userEntity.UserName;
                Session.Add(CommonConstants.USER_SESSION, userSession);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không đúng!");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [Route("Add")]
        [HttpPost]
        public ActionResult Create(UserView userView)
        {
            User user = new User();
            user.UpdateUserClient(userView);
            user.Position = "Client";
            var result = userService.Add(user);
            userService.Save();
            if (result.ID > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}