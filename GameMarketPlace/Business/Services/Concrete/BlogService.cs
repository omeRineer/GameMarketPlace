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

        public Task<IResult> AddAsync(Blog entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Create(BlogCreateDto blogCreateDto)
        {
            var entity = _mapper.Map<Blog>(blogCreateDto);

            await _blogRepository.AddAsync(entity);
            await _blogRepository.SaveAsync();

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(blogCreateDto.Cover.FileName)}";
            var fileBytes = Convert.FromBase64String(blogCreateDto.Cover.Base64);

            await _mediaService.AddAsync(new Media
            {
                EntityId = entity.Id,
                MediaTypeId = (int)MediaTypeEnum.BlogCoverImage,
                MediaPath = fileName
            });

            await _fileService.UploadFileAsync(fileBytes, new MeArch.Module.File.Model.FileOptionsParameter
            {
                Directory = $"{Enum.GetName(typeof(MediaTypeEnum), MediaTypeEnum.BlogCoverImage)}",
                NameTemplate = fileName
            });

            return new SuccessResult();
        }

        public Task<IResult> DeleteAsync(Blog entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<Blog>> GetById(Guid id)
        {
            var result = await _blogRepository.GetAsync(f=> f.Id.Equals(id));

            return new SuccessDataResult<Blog>(result);
        }

        public async Task<IDataResult<List<Blog>>> GetListAsync()
        {
            var result = await _blogRepository.GetListAsync();

            return new SuccessDataResult<List<Blog>>(result);
        }

        public Task<IResult> UpdateAsync(Blog entity)
        {
            throw new NotImplementedException();
        }
    }
}
