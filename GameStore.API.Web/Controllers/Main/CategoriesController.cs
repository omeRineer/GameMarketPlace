using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using MeArch.Module.File.Extensions;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;

namespace GameStore.API.Web.Controllers.Main
{
    public class CategoriesController : BaseController
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


    }
}
