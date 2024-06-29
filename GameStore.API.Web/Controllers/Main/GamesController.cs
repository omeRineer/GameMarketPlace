using Business.Services.Abstract;
using Entities.Models.Game.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;

namespace GameStore.API.Web.Controllers.Main
{
    public class GamesController : BaseController
    {
        IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        
    }
}
