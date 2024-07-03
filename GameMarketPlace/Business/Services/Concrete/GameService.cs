using AutoMapper;
using Business.Services.Abstract;
using Core.Business.BaseService;
using Core.DataAccess;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Dto.Media;
using Entities.Enum.Type;
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
using Entities.Models.Game.Dto;
using MassTransit;
using GameStore.Enterprise.Shared.Models;

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

            await _bus.Publish(new MediaUploadMessage
            {
                Base64 = request.Cover.Base64,
                EntityId = entity.Id,
                FileName = request.Cover.GenerateFileName(),
                MediaType = MediaTypeEnum.GameCoverImage
            });

            return new SuccessResult();
        }

        public async Task<IResult> UploadGameImagesAsync(GameImageUploadDto gameImageUploadDto)
        {
            //var mediaList = new List<Media>();
            //foreach (var file in HttpContextAccessor.HttpContext.Request.Form.Files)
            //{
            //    var newFileName = Guid.NewGuid().ToString();

            //    var uploadResult = await _fileService.UploadFileAsync(file, new MeArch.Module.File.Model.FileOptionsParameter
            //    {
            //        Directory = $"{Enum.GetName(typeof(MediaTypeEnum), MediaTypeEnum.GameImage)}/{gameImageUploadDto.EntityId}",
            //        NameTemplate = newFileName
            //    });

            //    mediaList.Add(new Media
            //    {
            //        EntityId = gameImageUploadDto.EntityId,
            //        MediaTypeId = (int)MediaTypeEnum.GameImage,
            //        MediaPath = uploadResult.Data.FileName
            //    });
            //}

            //await _mediaService.AddMediaListAsync(mediaList);

            return new SuccessResult();
        }
    }
}
