using Business.Services.Abstract;
using Core.Business.BaseService;
using Core.DataAccess;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class GameService : IGameService
    {
        readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<IResult> AddAsync(Game entity)
        {
            await _gameRepository.AddAsync(entity);
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Game entity)
        {
            _gameRepository.Delete(entity);
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<List<Game>>> GetListAsync()
        {
            var list = await _gameRepository.GetListAsync();

            return new SuccessDataResult<List<Game>>(list);
        }

        public async Task<IResult> UpdateAsync(Game entity)
        {
            _gameRepository.Update(entity);
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
