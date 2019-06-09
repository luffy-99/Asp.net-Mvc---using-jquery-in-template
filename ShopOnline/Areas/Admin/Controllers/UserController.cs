using Service;
using ShopOnline.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Infrastructure.Extension;
using Models;
using AutoMapper;
using ShopOnline.Mapping;
using PagedList;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [Route("Add")]
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [Route("Add")]
        [HttpPost]
        public ActionResult AddUser(UserViewAdmin userView)
        {
            User user = new User();
            user.UpdateUser(userView);
            var result = userService.Add(user);
            userService.Save();
            if (result.ID > 0)
            {
                return RedirectToAction("GetAllUser", "User");
            }
            return View();
        }
        [Route("Delete")]
        public ActionResult DeleteUser(int id)
        {
            var result = userService.Delete(id);
            userService.Save();
            if (result.ID > 0)
            {
                return RedirectToAction("GetAllUser", "User");
            }
            return View();
        }
        public ActionResult GetAllUser(int page=1, int pageSize = 2)
        {
            var result = userService.GetAll();
            IEnumerable<UserViewAdmin> userViews = AutoMapperConfiguration.Mapping.Map<IEnumerable<User>, IEnumerable<UserViewAdmin>>(result);
            userViews = userViews.ToPagedList(page, pageSize);
            return View(userViews);
        }
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            var userEntity = userService.GetUserById(id);
            var userView = AutoMapperConfiguration.Mapping.Map<User, UserViewAdmin>(userEntity);
            return View(userView);
        }
        [HttpPost]
        [Route("Update")]
        public ActionResult UpdateUser(UserViewAdmin userView)
        {
            User user = new User();
            user.UpdateUser(userView);
            userService.Update(user);
            userService.Save();
            return RedirectToAction("GetAllUser", "User");
        }
    }
}