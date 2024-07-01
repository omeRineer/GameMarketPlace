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

namespace Business.Services.Concrete
{
    public class GameService : IGameService
    {
        readonly IGameRepository _gameRepository;
        readonly IFileService _fileService;
        readonly IMediaService _mediaService;
        readonly NET.IHttpContextAccessor HttpContextAccessor;
        readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper, NET.IHttpContextAccessor httpContextAccessor, IFileService fileService, IMediaService mediaService)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
            _fileService = fileService;
            _mediaService = mediaService;
        }

        public async Task<IResult> CreateGameAsync(CreateGameDto createGameDto)
        {
            var entity = _mapper.Map<Game>(createGameDto);

            await _gameRepository.AddAsync(entity);
            await _gameRepository.SaveAsync();


            // TODO : Queueda yapılacak
            //var fileName = $"{Guid.NewGuid()}{Path.GetExtension(createGameDto.Cover.FileName)}";
            //var fileBytes = Convert.FromBase64String(createGameDto.Cover.Base64);
            //var media = new Media
            //{
            //    EntityId = entity.Id,
            //    MediaTypeId = (int)MediaTypeEnum.GameCoverImage,
            //    MediaPath = fileName
            //};
            //await _mediaService.AddAsync(media);


            //await _fileService.UploadFileAsync(fileBytes, new MeArch.Module.File.Model.FileOptionsParameter
            //{
            //    Directory = $"{Enum.GetName(typeof(MediaTypeEnum), MediaTypeEnum.GameCoverImage)}/{entity.Id}",
            //    NameTemplate = fileName
            //});

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
