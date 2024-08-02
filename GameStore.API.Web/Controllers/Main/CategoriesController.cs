﻿using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using MeArch.Module.File.Extensions;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;
using Models.Category.WebService;

namespace GameStore.API.Web.Controllers.Main
{
    public class CategoriesController : BaseController
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var result = await _categoryService.GetAsync(id);

            return Result(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateCategoryRequest request)
        {
            var result = await _categoryService.CreateAsync(request);

            return Result(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _categoryService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(UpdateCategoryRequest request)
        {
            var result = await _categoryService.UpdateAsync(request);

            return Result(result);
        }
    }
}
