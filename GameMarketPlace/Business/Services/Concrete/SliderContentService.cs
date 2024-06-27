using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Main;
using NET = Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeArch.Module.File.Service;
using Entities.Enum.Type;
using AutoMapper;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Entities.Models.SliderContent.Dto;

namespace Business.Services.Concrete
{
    public class SliderContentService : ISliderContentService
    {
        readonly ISliderContentRepository _sliderContentRepository;
        readonly NET.IHttpContextAccessor HttpContextAccessor;
        readonly IFileService _fileService;
        readonly IMediaService _mediaService;
        readonly IMapper _mapper;

        public SliderContentService(ISliderContentRepository sliderContentRepository, NET.IHttpContextAccessor httpContextAccessor, IFileService fileService, IMediaService mediaService, IMapper mapper)
        {
            _sliderContentRepository = sliderContentRepository;
            HttpContextAccessor = httpContextAccessor;
            _fileService = fileService;
            _mediaService = mediaService;
            _mapper = mapper;
        }

        public Task<IResult> AddAsync(SliderContent entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> CreateSliderContentAsync(SliderContentCreateDto sliderContentCreateDto)
        {
            var entity = _mapper.Map<SliderContent>(sliderContentCreateDto);

            await _sliderContentRepository.AddAsync(entity);
            await _sliderContentRepository.SaveAsync();

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(sliderContentCreateDto.Image.FileName)}";
            var fileBytes = Convert.FromBase64String(sliderContentCreateDto.Image.Base64);
            var sliderType = (SliderTypeEnum)Enum.ToObject(typeof(SliderTypeEnum), sliderContentCreateDto.SliderTypeId);
            var mediaType = sliderType == SliderTypeEnum.SliderItem ? MediaTypeEnum.SliderItemImage : MediaTypeEnum.SliderSideItemImage;

            await _mediaService.AddAsync(new Media
            {
                EntityId = entity.Id,
                MediaTypeId = (int)mediaType,
                MediaPath = fileName
            });

            await _fileService.UploadFileAsync(fileBytes, new MeArch.Module.File.Model.FileOptionsParameter
            {
                Directory = $"{Enum.GetName(typeof(MediaTypeEnum), mediaType)}/{entity.Id}",
                NameTemplate = fileName
            });

            return new SuccessResult();
        }

        public Task<IResult> DeleteAsync(SliderContent entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<SliderContent>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<SliderContent>>> GetSliderContentByIsActive()
        {
            var result = await _sliderContentRepository.GetListAsync(filter: f => f.IsActive,
                                                                     includes: i => i.Include(x => x.SliderType));

            return new SuccessDataResult<List<SliderContent>>(result);
        }

        public Task<IResult> UpdateAsync(SliderContent entity)
        {
            throw new NotImplementedException();
        }
    }
}
