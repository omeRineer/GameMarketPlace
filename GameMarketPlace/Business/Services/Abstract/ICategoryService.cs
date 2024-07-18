using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Main;
using Models.Category.WebService;
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
