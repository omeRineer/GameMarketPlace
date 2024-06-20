using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using UserInterface.Models.Blog;

namespace UserInterface.Controllers
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
            var blogs = await _blogService.GetListAsync();
            var coverMedias = await _mediaService.GetMediaListByEntites(blogs.Data.Select(s => s.Id).ToList());

            var result = blogs.Data.Select(s => new BlogListViewModel
            {
                Id = s.Id,
                Header = s.Header,
                ReaderCount = s.ReaderCount,
                CoverPath = coverMedias?.Data?.FirstOrDefault(f => f.EntityId == s.Id)?.MediaPath
            }).ToList();

            return View(result);
        }

        public async Task<IActionResult> GetDetail([FromRoute] Guid id)
        {
            var result = await _blogService.GetById(id);

            return View(result.Data);
        }
    }
}
