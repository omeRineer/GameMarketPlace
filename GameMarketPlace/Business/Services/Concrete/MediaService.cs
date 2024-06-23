using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Dto.Media;
using Entities.Enum.Type;
using Entities.Main;
using MeArch.Module.File.Service;
using NET = Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Abstract;

namespace Business.Services.Concrete
{
    public class MediaService : IMediaService
    {
        readonly IMediaRepository _mediaRepository;
        readonly IFileService _fileService;
        readonly NET.IHttpContextAccessor HttpContextAccessor;

        public MediaService(IMediaRepository mediaRepository, IFileService fileService, NET.IHttpContextAccessor httpContextAccessor)
        {
            _mediaRepository = mediaRepository;
            _fileService = fileService;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<IResult> AddAsync(Media entity)
        {
            await _mediaRepository.AddAsync(entity);
            await _mediaRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> AddMediaListAsync(List<Media> mediaList)
        {
            await _mediaRepository.AddRangeAsync(mediaList);
            await _mediaRepository.SaveAsync();

            return new SuccessResult();
        }

        public Task<IResult> DeleteAsync(Media entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<Media>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<Media>> GetMediaByEntityId(Guid entityId)
        {
            var firstMedia = await _mediaRepository.GetAsync(f => f.EntityId == entityId);

            return new SuccessDataResult<Media>(firstMedia);
        }

        public async Task<IDataResult<List<Media>>> GetMediaListByEntites(List<Guid> EntityIdList)
        {
            var mediaList = await _mediaRepository.GetListAsync(filter: f => EntityIdList.Contains(f.EntityId),
                                                                includes: i => i.Include(x => x.MediaType));

            return new SuccessDataResult<List<Media>>(mediaList);
        }

        public async Task<IDataResult<List<Media>>> GetMediaListByEntityId(Guid entityId)
        {
            var mediaList = await _mediaRepository.GetListAsync(f => f.EntityId == entityId, includes: i => i.Include(x => x.MediaType));

            return new SuccessDataResult<List<Media>>(mediaList);
        }

        public Task<IResult> UpdateAsync(Media entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> UploadMedia(MediaUploadDto mediaUploadDto)
        {
            var mediaList = new List<Media>();
            foreach (var file in HttpContextAccessor.HttpContext.Request.Form.Files)
            {
                var newFileName = Guid.NewGuid().ToString();

                var uploadResult = await _fileService.UploadFileAsync(file, new MeArch.Module.File.Model.FileOptionsParameter
                {
                    Directory = $"{Enum.GetName(typeof(MediaTypeEnum), MediaTypeEnum.GameImage)}/{mediaUploadDto.EntityId}",
                    NameTemplate = newFileName
                });

                mediaList.Add(new Media
                {
                    EntityId = mediaUploadDto.EntityId,
                    MediaTypeId = (int)MediaTypeEnum.GameImage,
                    MediaPath = uploadResult.Data.FileName
                });
            }

            await _mediaRepository.AddRangeAsync(mediaList);
            await _mediaRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
