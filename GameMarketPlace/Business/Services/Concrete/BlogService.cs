using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Dto;
using Entities.Dto.Blog;
using Entities.Enum.Type;
using Entities.Main;
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

        public BlogService(IBlogRepository blogRepository, IMapper mapper, IMediaService mediaService, IFileService fileService)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _mediaService = mediaService;
            _fileService = fileService;
        }

        public async Task<IResult> CreateAsync(BlogCreateDto blogCreateDto)
        {
            var entity = _mapper.Map<Blog>(blogCreateDto);
            entity.GeneratedId();

            await _blogRepository.AddAsync(entity);

            // TODO : Queue da dosya ekleme işlemi

            return new SuccessResult();
        }
    }
}
