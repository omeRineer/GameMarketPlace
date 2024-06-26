using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using Entities.Enum.Type;
using Entities.Main;
using Entities.Models.Game.ViewModels;
using Entities.Models.Media.ViewModels;
using MeArch.Module.Security.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using UserInterface.Models.Game;

namespace UserInterface.Controllers
{
    public class GamesController : Controller
    {
        readonly IGameService _gameService;
        readonly IMediaService _mediaService;
        readonly ICategoryService _categoryService;
        readonly IMapper _mapper;
        readonly CurrentUser _currentUser;

        public GamesController(IGameService gameService, IMediaService mediaService, IMapper mapper, CurrentUser currentUser, ICategoryService categoryService)
        {
            _gameService = gameService;
            _mediaService = mediaService;
            _mapper = mapper;
            _currentUser = currentUser;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetListAsync();
            var trendGames = await _gameService.GetListAsync();
            var medias = await _mediaService.GetMediaListByEntites(trendGames.Data.Select(s => s.Id).ToList());

            ViewBag.Categories = categories.Data;
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

            gameViewModel.GameMedias = gameMedias.Data.Where(f => f.MediaTypeId == (int)MediaTypeEnum.GameImage).Select(s => new MediaViewModel
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
