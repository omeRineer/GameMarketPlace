using Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;
using MA = Core.Entities.DTO.File;

namespace GameStore.API.Web.Controllers.Main
{
    public class BlogsController : BaseController
    {
        readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Test(MA.File file)
        {
            await _blogService.BusDemo(file);

            return Ok();
        }

    }
}
