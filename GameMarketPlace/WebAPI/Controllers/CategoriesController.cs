using Business.Services.Abstract;
using Entities.Dto.Category;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
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

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryService.GetListAsync();

            return result.Success ? Ok(result) 
                                  : BadRequest(result);       
        }
    }
}
