using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.ViewComponents
{
    public class MostPlayedViewComponent : ViewComponent
    {
        readonly IGameService _gameService;

        public MostPlayedViewComponent(IGameService gameService)
        {
            _gameService = gameService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
