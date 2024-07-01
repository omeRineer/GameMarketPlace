using AutoMapper;
using Business.Services.Abstract;
using MA = Core.Entities.DTO.File;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Dto;
using Entities.Enum.Type;
using Entities.Main;
using Entities.Models.Blog.Rest;
using GameStore.Enterprise.Shared.Models;
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
        readonly IMapper _mapper;
        readonly IMediaService _mediaService;
        readonly IFileService _fileService;
        readonly IBus _bus;

        public BlogService(IBlogRepository blogRepository, IMapper mapper, IMediaService mediaService, IFileService fileService, IBus bus)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _mediaService = mediaService;
            _fileService = fileService;
            _bus = bus;
        }

        public async Task<IResult> BusDemo(MA.File file)
        {
            var bytes = Convert.FromBase64String(file.Base64);

            await _fileService.UploadFileAsync(bytes, new MeArch.Module.File.Model.FileOptionsParameter
            {
                Directory = "Test",
                NameTemplate = file.FileName
            });

            return new SuccessResult();
        }

        public async Task<IResult> CreateAsync(CreateBlogRequest createBlogRequest)
        {
            var entity = _mapper.Map<Blog>(createBlogRequest);
            entity.GeneratedId();

            await _blogRepository.AddAsync(entity);

            // TODO : Queue da dosya ekleme işlemi

            return new SuccessResult();
        }
    }
}
