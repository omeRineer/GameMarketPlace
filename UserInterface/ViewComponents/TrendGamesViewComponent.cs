using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using Entities.Main;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.ViewComponents
{
    public class TrendGamesViewComponent : ViewComponent
    {
        readonly IGameService _gameService;

        public TrendGamesViewComponent(IGameService gameService)
        {
            _gameService = gameService;
        }

        public IViewComponentResult Invoke()
        {
            var trendGames = Task.Run<IDataResult<List<Game>>>(async () => await _gameService.GetListAsync()).Result.Data.Take(4);

            return View(trendGames.ToList());
        }
    }
}
