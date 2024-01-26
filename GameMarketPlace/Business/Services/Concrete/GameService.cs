using AutoMapper;
using Business.Services.Abstract;
using Core.Business.BaseService;
using Core.DataAccess;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Dto.Game;
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
        readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(Game entity)
        {
            await _gameRepository.AddAsync(entity);
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> AddAsyncDto(GameAddDto gameAddDto)
        {
            var entity = _mapper.Map<Game>(gameAddDto);

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

        public async Task<IResult> DeleteAsyncDto(GameDeleteDto gameDeleteDto)
        {
            var entity = await _gameRepository.GetAsync(x => x.Equals(gameDeleteDto));
            _gameRepository.Delete(entity);
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public Task<IDataResult<GameDto>> GetByIdAsyncDto(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<Game>>> GetListAsync()
        {
            var list = await _gameRepository.GetListAsync();

            return new SuccessDataResult<List<Game>>(list);
        }

        public Task<IDataResult<List<GameDto>>> GetListAsyncDto()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> UpdateAsync(Game entity)
        {
            _gameRepository.Update(entity);
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public Task<IResult> UpdateAsyncDto(GameEditDto gameEditDto)
        {
            throw new NotImplementedException();
        }
    }
}
