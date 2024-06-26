﻿using AutoMapper;
using Entities.Dto.Blog;
using Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogCreateDto, Blog>().ReverseMap();
        }
    }
}
