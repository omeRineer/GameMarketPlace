using AutoMapper;
using Business.Services.Abstract;
using Core.Business.BaseService;
using Core.DataAccess;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Main;
using NET = Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeArch.Module.File.Service;
using System.IO;
using Entities.Models.Game.Rest;
using MassTransit;
using GameStore.Enterprise.Shared.MessageModels;
using Entities.Models.Blog.Rest;
using Entities.Enum.Type;

namespace Business.Services.Concrete
{
    public class GameService : IGameService
    {
        readonly IGameRepository _gameRepository;
        readonly NET.IHttpContextAccessor HttpContextAccessor;
        readonly IMapper _mapper;
        readonly IBus _bus;

        public GameService(IGameRepository gameRepository, IMapper mapper, NET.IHttpContextAccessor httpContextAccessor, IBus bus)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
            _bus = bus;
        }

        public async Task<IResult> CreateAsync(CreateGameRequest request)
        {
            var entity = _mapper.Map<Game>(request);

            await _gameRepository.AddAsync(entity);
            await _gameRepository.SaveAsync();

            await _bus.Publish(new UploadMediaMessage
            {
                Base64 = request.Cover.Base64,
                EntityId = entity.Id,
                FileName = request.Cover.GenerateFileName(),
                MediaType = MediaTypeEnum.GameCoverImage
            });

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _gameRepository.GetAsync(f => f.Id == id);

            await _gameRepository.DeleteAsync(entity);
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(UpdateGameRequest updateGameRequest)
        {
            var entity = await _gameRepository.GetAsync(f => f.Id == updateGameRequest.Id);
            var mappedEntity = _mapper.Map(updateGameRequest, entity);

            await _gameRepository.UpdateAsync(entity);
            await _gameRepository.SaveAsync();

            if (updateGameRequest.Cover != null)
                await _bus.Publish(new UploadMediaMessage
                {
                    MediaType = MediaTypeEnum.GameCoverImage,
                    Base64 = updateGameRequest.Cover.Base64,
                    EntityId = entity.Id,
                    FileName = updateGameRequest.Cover.GenerateFileName()
                });

            return new SuccessResult();
        }
    }
}
