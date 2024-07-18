using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.UserInterface.Controllers
{
    public class BlogsController : Controller
    {
        readonly IBlogService _blogService;
        readonly IMediaService _mediaService;

        public BlogsController(IBlogService blogService, IMediaService mediaService)
        {
            _blogService = blogService;
            _mediaService = mediaService;
        }

        public async Task<IActionResult> Index()
        {

            return View();
        }

        public async Task<IActionResult> GetDetail([FromRoute] Guid id)
        {
            return View();
        }
    }
}
