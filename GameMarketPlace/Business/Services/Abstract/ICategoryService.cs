using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Main;
using Entities.Models.Blog.Rest;
using Entities.Models.Category.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IResult> CreateAsync(CreateCategoryRequest request);
        Task<IResult> UpdateAsync(UpdateCategoryRequest updateCategoryRequest);
        Task<IResult> DeleteAsync(Guid id);
    }
}
