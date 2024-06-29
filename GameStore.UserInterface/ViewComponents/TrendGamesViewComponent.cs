using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using Entities.Enum.Type;
using Entities.Main;
using Microsoft.AspNetCore.Mvc;
using GameStore.UserInterface.Models.Game;

namespace GameStore.UserInterface.ViewComponents
{
    public class TrendGamesViewComponent : ViewComponent
    {
        readonly IGameService _gameService;
        readonly IMediaService _mediaService;

        public TrendGamesViewComponent(IGameService gameService, IMediaService mediaService)
        {
            _gameService = gameService;
            _mediaService = mediaService;
        }

        public IViewComponentResult Invoke()
        {
            //var trendGames = Task.Run<IDataResult<List<Game>>>(async () => await _gameService.GetListAsync()).Result.Data;
            //var medias = Task.Run<IDataResult<List<Media>>>(async () => await _mediaService.GetMediaListByEntites(trendGames.Select(s => s.Id).ToList()));

            //var result = trendGames.Select(s => new GameListViewModel
            //{
            //    Id = s.Id,
            //    CategoryId = s.CategoryId,
            //    CategoryName = s.Category.Name,
            //    Name = s.Name,
            //    Price = s.Price,
            //    CoverPath = medias.Result.Data.FirstOrDefault(f => f.EntityId.Equals(s.Id) && f.MediaTypeId == (int)MediaTypeEnum.GameCoverImage)?.MediaPath
            //}).ToList();

            return View();
        }
    }
}
