using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ECommerce_Shop_Online_MVC_Model.Models;
using ECommerce_Shop_Online_MVC_Web.Models;

namespace ECommerce_Shop_Online_MVC_Web.Mappings
{
    public class MappingProfile : Profile
    {
        //public static IMapper Mapper { get; set; }
        //public static void Init()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {

        //        #region Domain To ViewModel
        //        cfg.CreateMap<Post, PostViewModel>().ReverseMap();
        //        cfg.CreateMap<PostCategory, PostCategoryViewModel>().ReverseMap();
        //        cfg.CreateMap<Tag, TagViewModel>().ReverseMap();
        //        cfg.CreateMap<ProductCategory, ProductCategoryViewModel>().ReverseMap();
        //        cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
        //        cfg.CreateMap<ProductTag, ProductTagViewModel>().ReverseMap();
        //        #endregion

        //    });
        //    Mapper = config.CreateMapper();
        //}
        public MappingProfile()
        {
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<PostCategory, PostCategoryViewModel>().ReverseMap();
            CreateMap<Tag, TagViewModel>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ProductTag, ProductTagViewModel>().ReverseMap();
        }
    }
}