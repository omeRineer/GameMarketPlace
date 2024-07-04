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
using Entities.Models.SliderContent.Rest;
using GameStore.Enterprise.Shared.MessageModels;
using MassTransit;
using Entities.Models.Game.Rest;

namespace Business.Services.Concrete
{
    public class SliderContentService : ISliderContentService
    {
        readonly ISliderContentRepository _sliderContentRepository;
        readonly IMapper _mapper;
        readonly IBus _bus;

        public SliderContentService(ISliderContentRepository sliderContentRepository, IMapper mapper, IBus bus)
        {
            _sliderContentRepository = sliderContentRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public async Task<IResult> CreateAsync(CreateSliderContentRequest request)
        {
            var entity = _mapper.Map<SliderContent>(request);

            await _sliderContentRepository.AddAsync(entity);
            await _sliderContentRepository.SaveAsync();

            await _bus.Publish(new UploadMediaMessage
            {
                Base64 = request.Image.Base64,
                EntityId = entity.Id,
                FileName = request.Image.GenerateFileName(),
                MediaType = MediaTypeEnum.SliderItemImage
            });

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _sliderContentRepository.GetAsync(f => f.Id == id);

            await _sliderContentRepository.DeleteAsync(entity);
            await _sliderContentRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(UpdateSliderContentRequest request)
        {
            var entity = await _sliderContentRepository.GetAsync(f => f.Id == request.Id);
            var mappedEntity = _mapper.Map(request, entity);

            await _sliderContentRepository.UpdateAsync(entity);
            await _sliderContentRepository.SaveAsync();

            if (request.Image != null)
                await _bus.Publish(new UploadMediaMessage
                {
                    MediaType = MediaTypeEnum.GameCoverImage,
                    Base64 = request.Image.Base64,
                    EntityId = entity.Id,
                    FileName = request.Image.GenerateFileName()
                });

            return new SuccessResult();
        }
    }
}
