using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using MeArch.Module.File.Extensions;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;
using Entities.Models.Category.Rest;

namespace GameStore.API.Web.Controllers.Main
{
    public class CategoriesController : BaseController
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateCategoryRequest request)
        {
            var result = await _categoryService.CreateAsync(request);

            return Result(result);
        }
    }
}
