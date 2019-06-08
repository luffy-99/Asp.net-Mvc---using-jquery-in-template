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
            if (result.ID > 0)
            {
                return RedirectToAction("GetAll", "User");
            }
            return View();
        }
        [Route("Delete")]
        public ActionResult DeleteUser(int id)
        {
            var result = userService.Delete(id);
            if (result.ID > 0)
            {
                return RedirectToAction("GetAll", "User");
            }
            return View();
        }
        [Route("GetAll")]
        public ActionResult GetAllUser()
        {
            return View();
        }
        public JsonResult GetAll(int page, int pageSize = 2)
        {
            var result = userService.GetAll();
            IEnumerable<UserViewAdmin> userViews = AutoMapperConfiguration.Mapping.Map<IEnumerable<User>, IEnumerable<UserViewAdmin>>(result);
            var userPagging = userViews.Skip((page - 1) * pageSize).Take(pageSize);
            var totalRow = userViews.Count();
            return Json(new {
                data = userPagging,
                total = totalRow,
                status = true
            },JsonRequestBehavior.AllowGet);
        }
        [Route("Update")]
        public ActionResult UpdateUser(UserViewAdmin userView)
        {
            User user = new User();
            user.UpdateUser(userView);
            userService.Update(user);
            return View();
        }
    }
}