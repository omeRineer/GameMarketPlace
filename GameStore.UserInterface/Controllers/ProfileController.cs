using Business.Services.Abstract;
using Entities.Enum.Type;
using Entities.Main;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GameStore.UserInterface.Controllers
{
    public class ProfileController : Controller
    {
        readonly IMemoryCache _memoryCache;
        readonly IMediaService _mediaService;

        public ProfileController(IMemoryCache memoryCache, IMediaService mediaService)
        {
            _memoryCache = memoryCache;
            _mediaService = mediaService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            //var userGames = _memoryCache.Get<List<Game>>("UserGames");
            //var medias = await _mediaService.GetMediaListByEntites(userGames.Select(s => s.Id).ToList());

            //var result = userGames.Select(s => new GameListViewModel
            //{
            //    Id = s.Id,
            //    CategoryId = s.CategoryId,
            //    CategoryName = s.Category.Name,
            //    Name = s.Name,
            //    Price = s.Price,
            //    CoverPath = medias.Data.FirstOrDefault(f => f.EntityId.Equals(s.Id) && f.MediaTypeId == (int)MediaTypeEnum.GameCoverImage)?.MediaPath
            //}).ToList();

            return View();
        }
    }
}
