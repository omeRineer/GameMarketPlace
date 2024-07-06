using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
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
using Entities.Models.Media.Rest;
using MassTransit;
using Entities.Enum.Type;
using Entities.Models.Enterprise;

namespace Business.Services.Concrete
{
    public class MediaService : IMediaService
    {
        readonly IMediaRepository _mediaRepository;
        readonly IFileService _fileService;
        readonly IBus _bus;
        readonly NET.IHttpContextAccessor HttpContextAccessor;

        public MediaService(IMediaRepository mediaRepository, IFileService fileService, NET.IHttpContextAccessor httpContextAccessor, IBus bus)
        {
            _mediaRepository = mediaRepository;
            _fileService = fileService;
            HttpContextAccessor = httpContextAccessor;
            _bus = bus;
        }

        public async Task<IResult> CreateAsync(Media media)
        {
            await _mediaRepository.AddAsync(media);
            await _mediaRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<List<Media>>> GetListByEntityAsync(Guid entityId, MediaTypeEnum? mediaType = null)
        {
            var result = await _mediaRepository.GetListAsync(f => f.EntityId == entityId);

            return new SuccessDataResult<List<Media>>(result);
        }

        public async Task<IDataResult<List<Media>>> GetListByMediaTypeAsync(MediaTypeEnum mediaType)
        {
            var result = await _mediaRepository.GetListAsync(f => f.MediaTypeId == (int)mediaType);

            return new SuccessDataResult<List<Media>>(result);
        }

        public async Task<IResult> UploadMediaCollectionAsync(UploadMediaCollectionRequest request)
        {
            foreach (var mediaItem in request.Medias)
            {
                await _bus.Publish(new UploadMediaMessage
                {
                    EntityId = request.EntityId,
                    MediaType = (MediaTypeEnum)Enum.ToObject(typeof(MediaTypeEnum), request.MediaTypeId),
                    Base64 = mediaItem.Base64,
                    FileName = mediaItem.FileName,
                    Size = mediaItem.Size
                });
            }

            return new SuccessResult();
        }
    }
}
