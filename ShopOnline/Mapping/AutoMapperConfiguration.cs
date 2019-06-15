using AutoMapper;
using Models;
using ShopOnline.Areas.Admin.Models;
using ShopOnline.Models;
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
                cfg.CreateMap<ProductCategory, ProductCategoryViewAdmin>();
                cfg.CreateMap<MenuGroup, MenuGroupView>();
                cfg.CreateMap<ProductCategory, ProductCategoryView>();
                cfg.CreateMap<Product, ProductView>();
            });
            Mapping = mapperConfig.CreateMapper();
        }
        
    }
}