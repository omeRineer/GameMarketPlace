using AutoMapper;
using Business.Services.Abstract;
using MA = Core.Entities.DTO.File;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Dto;
using Entities.Enum.Type;
using Entities.Main;
using Entities.Models.Blog.Rest;
using GameStore.Enterprise.Shared.MessageModels;
using MassTransit;
using MeArch.Module.File.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class BlogService : IBlogService
    {
        readonly IBlogRepository _blogRepository;
        readonly IMediaService _mediaService;
        readonly IMapper _mapper;
        readonly IBus _bus;

        public BlogService(IBlogRepository blogRepository, IMapper mapper, IBus bus, IMediaService mediaService)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _bus = bus;
            _mediaService = mediaService;
        }

        public async Task<IResult> CreateAsync(CreateBlogRequest createBlogRequest)
        {
            var entity = _mapper.Map<Blog>(createBlogRequest);
            entity.GeneratedId();

            await _blogRepository.AddAsync(entity);
            await _blogRepository.SaveAsync();

            await _bus.Publish(new UploadMediaMessage
            {
                MediaType = MediaTypeEnum.BlogCoverImage,
                Base64 = createBlogRequest.Cover.Base64,
                EntityId = entity.Id,
                FileName = createBlogRequest.Cover.GenerateFileName(),
            });

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _blogRepository.GetAsync(f => f.Id == id);
            var medias = await _mediaService.GetListByEntityAsync(id);

            medias.Data.ForEach(item => item.RecordState = false);

            await _blogRepository.DeleteAsync(entity);
            await _blogRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(UpdateBlogRequest updateBlogRequest)
        {
            var entity = await _blogRepository.GetAsync(f => f.Id == updateBlogRequest.Id);
            var mappedEntity = _mapper.Map(updateBlogRequest, entity);

            await _blogRepository.UpdateAsync(entity);
            await _blogRepository.SaveAsync();

            if (updateBlogRequest.Cover != null)
                await _bus.Publish(new UploadMediaMessage
                {
                    MediaType = MediaTypeEnum.BlogCoverImage,
                    Base64 = updateBlogRequest.Cover.Base64,
                    EntityId = entity.Id,
                    FileName = updateBlogRequest.Cover.GenerateFileName()
                });

            return new SuccessResult();
        }
    }
}
