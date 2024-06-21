using Business.Services.Abstract;
using Entities.Dto.Category;
using Entities.Dto.Game;
using Entities.Dto.Media;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    public class GamesController : BaseController
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

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(GameEditDto gameEditDto)
        {
            var result = await _gameService.UpdateAsyncDto(gameEditDto);

            return result.Success ? Ok(result)
                                  : BadRequest(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _gameService.DeleteByIdAsync(id);

            return result.Success ? Ok(result)
                                  : BadRequest(result);
        }

        [HttpGet("GetGames")]
        public async Task<IActionResult> GetGamesAsync()
        {
            var result = await _gameService.GetListAsyncDto();

            return result.Success ? Ok(result)
                                  : BadRequest(result);
        }

        [HttpGet("GetGame/{id}")]
        public async Task<IActionResult> GetGameAsync(Guid id)
        {
            var result = await _gameService.GetByIdAsyncDto(id);

            return result.Success ? Ok(result)
                                  : BadRequest(result);
        }

        [HttpPost("UploadGameImages")]
        public async Task<IActionResult> UploadGameImages([FromQuery] GameImageUploadDto gameImageUploadDto)
        {
            var result = await _gameService.UploadGameImagesAsync(gameImageUploadDto);

            return Result(result);
        }
    }
}
