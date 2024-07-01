using Business.Services.Abstract;
using GameStore.Enterprise.Shared.Models;
using MassTransit;
using MeArch.Module.File.Service;

namespace GameStore.Enterprise.Consumer.Consumers
{
    public class MediaUploadConsumer : IConsumer<MediaUploadMessage>
    {
        readonly IMediaService _mediaService;
        readonly IFileService _fileService;

        public MediaUploadConsumer(IMediaService mediaService, IFileService fileService)
        {
            _mediaService = mediaService;
            _fileService = fileService;
        }

        public Task Consume(ConsumeContext<MediaUploadMessage> context)
        {


            return Task.CompletedTask;
        }
    }
}
