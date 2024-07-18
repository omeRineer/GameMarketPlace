using Core.Business;
using Core.Entities.DTO.File;
using Core.Utilities.ResultTool;
using Models.Blog.WebService;
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
        Task<IResult> UpdateAsync(UpdateBlogRequest updateBlogRequest);
        Task<IResult> DeleteAsync(Guid id);
    }
}
