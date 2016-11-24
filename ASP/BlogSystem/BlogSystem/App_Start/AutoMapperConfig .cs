using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BlogSystem.Models;

namespace BlogSystem
{
    public class AutoMapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Post, PostViewModel>().ReverseMap();
                cfg.CreateMap<Comment, CommentViewModel>().ReverseMap();
            });
        }
    }
}