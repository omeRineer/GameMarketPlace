using Business.Services.Abstract;
using Entities.Models.Game.Rest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;
using Entities.Models.Category.Rest;

namespace GameStore.API.Web.Controllers.Main
{
    public class GamesController : BaseController
    {
        IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateGameRequest request)
        {
            var result = await _gameService.CreateAsync(request);

            return Result(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _gameService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(UpdateGameRequest request)
        {
            var result = await _gameService.UpdateAsync(request);

            return Result(result);
        }
    }
}
