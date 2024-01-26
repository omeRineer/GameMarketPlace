using Business.Services.Abstract;
using Entities.Dto.Category;
using Entities.Dto.Game;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(GameAddDto gameAddDto)
        {
            var result = await _gameService.AddAsyncDto(gameAddDto);

            return result.Success ? Ok(result)
                                  : BadRequest(result);
        }

        [HttpGet("GetGames")]
        public async Task<IActionResult> GetGames()
        {
            var result = await _gameService.GetListAsync();

            return result.Success ? Ok(result)
                                  : BadRequest(result);
        }
    }
}
