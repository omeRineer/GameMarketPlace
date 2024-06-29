using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Main;
using Entities.Models.Blog.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IBlogService
    {
        Task<IResult> CreateAsync(CreateBlogRequest createBlogRequest);
    }
}
