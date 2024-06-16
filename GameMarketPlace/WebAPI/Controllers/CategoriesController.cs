using Business.Services.Abstract;
using Entities.Dto.Category;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    public class CategoriesController : BaseController
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CategoryAddDto categoryAddDto)
        {
            var result = await _categoryService.AddAsyncDto(categoryAddDto);

            return result.Success ? Ok(result)
                                  : BadRequest(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody]Guid id)
        {
            var result = await _categoryService.DeleteByIdAsync(id);

            return result.Success ? Ok(result)
                                  : BadRequest(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var result = await _categoryService.UpdateAsyncDto(categoryUpdateDto);

            return result.Success ? Ok(result)
                                  : BadRequest(result);
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var result = await _categoryService.GetListAsync();

            return result.Success ? Ok(result)
                                  : BadRequest(result);
        }

        [HttpGet("GetCategory/{id}")]
        public async Task<IActionResult> GetCategoryAsync(Guid id)
        {
            var result = await _categoryService.GetByIdAsyncDto(id);

            return result.Success ? Ok(result)
                                  : BadRequest(result);
        }
    }
}
