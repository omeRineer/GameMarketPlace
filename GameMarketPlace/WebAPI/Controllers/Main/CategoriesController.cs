using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using Entities.Models.Category.Dto;
using MeArch.Module.File.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers.Main
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

            return Result(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] Guid id)
        {
            var result = await _categoryService.DeleteByIdAsync(id);

            return Result(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var result = await _categoryService.UpdateAsyncDto(categoryUpdateDto);

            return Result(result);
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var result = await _categoryService.GetListAsync();

            return Result(result);
        }

        [HttpGet("GetCategory/{id}")]
        public async Task<IActionResult> GetCategoryAsync(Guid id)
        {
            var result = await _categoryService.GetByIdAsync(id);

            return Ok(result.Data);
        }


    }
}
