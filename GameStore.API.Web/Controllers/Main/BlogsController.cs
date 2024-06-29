using Business.Services.Abstract;
using Entities.Dto.Blog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers.Main
{
    public class BlogsController : BaseController
    {
        readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(BlogCreateDto blogCreateDto)
        {
            var result = await _blogService.CreateAsync(blogCreateDto);

            return Result(result);
        }
    }
}
