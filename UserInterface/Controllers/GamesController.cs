using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using Entities.Enum.Type;
using Entities.Main;
using Entities.Models.Game.ViewModels;
using Entities.Models.Media.ViewModels;
using Microsoft.AspNetCore.Mvc;
using UserInterface.Models.Game;

namespace UserInterface.Controllers
{
    public class GamesController : Controller
    {
        readonly IGameService _gameService;
        readonly IMediaService _mediaService;
        readonly IMapper _mapper;

        public GamesController(IGameService gameService, IMediaService mediaService, IMapper mapper)
        {
            _gameService = gameService;
            _mediaService = mediaService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var trendGames = await _gameService.GetListAsync();
            var medias = await _mediaService.GetMediaListByEntites(trendGames.Data.Select(s => s.Id).ToList());

            var result = trendGames.Data.Select(s => new GameListViewModel
            {
                Id = s.Id,
                CategoryId = s.CategoryId,
                CategoryName = s.Category.Name,
                Name = s.Name,
                Price = s.Price,
                CoverPath = medias.Data.FirstOrDefault(f => f.EntityId.Equals(s.Id) && f.MediaTypeId == (int)MediaTypeEnum.GameCoverImage)?.MediaPath
            }).ToList();

            return View(result);
        }

        public async Task<IActionResult> GetDetail([FromRoute] Guid id)
        {
            var game = (await _gameService.GetByIdAsync(id)).Data;
            var gameViewModel = _mapper.Map<GameDetailViewModel>(game);

            var gameMedias = await _mediaService.GetMediaListByEntityId(id);

            gameViewModel.GameMedias = gameMedias.Data.Select(s => new MediaViewModel
            {
                EntityId = s.EntityId,
                MediaPath = s.MediaPath,
                MediaType = s.MediaType.Description,
                MediaTypeId = s.MediaTypeId
            }).ToList();


            return View(gameViewModel);
        }
    }
}
