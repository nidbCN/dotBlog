﻿using AutoMapper;
using DotBlog.Server.Entities;
using DotBlog.Server.Models;

namespace DotBlog.Server.Profiles
{
    public class ArticleDtoProfile : Profile
    {
        public ArticleDtoProfile()
        {
            CreateMap<ArticleDto, Article>();
        }
    }
}
