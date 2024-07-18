using AutoMapper;
using Entities.Main;
using Models.Blog.WebService;
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
            #region Rest
            CreateMap<CreateBlogRequest, Blog>();
            CreateMap<UpdateBlogRequest, Blog>();
            #endregion
        }
    }
}
