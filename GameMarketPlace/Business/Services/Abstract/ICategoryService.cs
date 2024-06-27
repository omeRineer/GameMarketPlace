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
    public interface ICategoryService : IEntityService<Category, Guid>
    {
        Task<IDataResult<List<CategoryDto>>> GetListAsyncDto();
        Task<IDataResult<Category>> GetByIdAsync(Guid id);
        Task<IDataResult<CategoryDto>> GetByIdAsyncDto(Guid id);
        Task<IResult> AddAsyncDto(CategoryAddDto categoryAddDto);
        Task<IResult> UpdateAsyncDto(CategoryUpdateDto categoryUpdateDto);
    }
}
