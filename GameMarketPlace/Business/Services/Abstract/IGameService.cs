﻿using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Dto.Category;
using Entities.Main;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Entities.Dto.Game;

namespace Business.Services.Abstract
{
    public interface IGameService : IEntityService<Game>
    {
        Task<IDataResult<List<GameDto>>> GetListAsyncDto();
        Task<IDataResult<GameDto>> GetByIdAsyncDto(Guid id);
        Task<IResult> AddAsyncDto(GameAddDto gameAddDto);
        Task<IResult> DeleteAsyncDto(GameDeleteDto gameDeleteDto);
        Task<IResult> UpdateAsyncDto(GameEditDto gameEditDto);
    }
}
