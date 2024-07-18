using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Main;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Models.Game.WebService;

namespace Business.Services.Abstract
{
    public interface IGameService
    {
        Task<IResult> CreateAsync(CreateGameRequest request);
        Task<IResult> UpdateAsync(UpdateGameRequest updateGameRequest);
        Task<IResult> DeleteAsync(Guid id);
    }
}
