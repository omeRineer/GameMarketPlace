using Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;
using MA = Core.Entities.DTO.File;
using Core.Utilities.Filters;
using Core.Entities.Concrete.ProcessGroups.Enums.Types;
using Models.Blog.WebService;

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
        [Benchmark(1000, LogTypeEnum.Notification)]
        public IActionResult CreateAsync(CreateBlogRequest request)
        {
            Thread.Sleep(5000);
            //var result = await _blogService.CreateAsync(request);

            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _blogService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(UpdateBlogRequest request)
        {
            var result = await _blogService.UpdateAsync(request);

            return Result(result);
        }
    }
}
