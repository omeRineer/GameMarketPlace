using Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;
using MA = Core.Entities.DTO.File;
using Entities.Models.Blog.Rest;

namespace GameStore.API.Web.Controllers.Main
{
    public class BlogsController : BaseController
    {
        readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateBlogRequest request)
        {
            var result = await _blogService.CreateAsync(request);

            return Result(result);
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _blogService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(UpdateBlogRequest request)
        {
            var result = await _blogService.UpdateAsync(request);

            return Result(result);
        }
    }
}
