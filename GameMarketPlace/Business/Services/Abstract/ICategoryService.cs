using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Main;
using Entities.Models.Category.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> GetByIdAsync(Guid id);
        Task<IDataResult<List<CategoryDto>>> GetListAsync();
        Task<IResult> DeleteByIdAsync(Guid id);
    }
}
