using AutoMapper;
using Models;
using ShopOnline.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Mapping
{
    public class AutoMapperConfiguration
    {
        public static IMapper Mapping;
        public static void RegisterMapping()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewAdmin>();
                cfg.CreateMap<User, UserViewAdmin>();
            });
            Mapping = mapperConfig.CreateMapper();
        }
        
    }
}