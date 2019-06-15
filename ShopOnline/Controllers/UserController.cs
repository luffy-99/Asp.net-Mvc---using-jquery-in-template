using Models;
using Service;
using ShopOnline.Infrastructure.Core;
using ShopOnline.Mapping;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class UserController : BaseControllerClient
    {
        // GET: User
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        public ActionResult ProfileClient(int id)
        {
            var userEntity = userService.GetUserById(id);
            var userView = AutoMapperConfiguration.Mapping.Map<User, UserView>(userEntity);
            return View(userView);
        }
    }
}