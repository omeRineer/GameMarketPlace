using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Dto.Category;
using Entities.Main;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Entities.Dto.Game;

namespace Business.Services.Abstract
{
    public interface IGameService : IEntityService<Game, Guid>
    {
        Task<IResult> CreateGameAsync(CreateGameDto createGameDto);
        Task<IResult> UploadGameImagesAsync(GameImageUploadDto gameImageUploadDto);
        Task<IDataResult<List<GameDto>>> GetListAsyncDto();
        Task<IDataResult<GameDto>> GetByIdAsyncDto(Guid id);
        Task<IDataResult<Game>> GetByIdAsync(Guid id);
        Task<IResult> AddAsyncDto(GameAddDto gameAddDto);
        Task<IResult> UpdateAsyncDto(GameEditDto gameEditDto);
    }
}
