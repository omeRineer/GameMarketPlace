using Business.Services.Abstract;
using Configuration;
using Entities.Enum.Type;
using GameStore.Enterprise.Shared.MessageModels;
using MassTransit;
using MeArch.Module.File.Service;

namespace GameStore.Enterprise.Consumer.Consumers
{
    public class UploadMediaConsumer : IConsumer<UploadMediaMessage>
    {
        readonly IMediaService _mediaService;
        readonly IFileService _fileService;

        public UploadMediaConsumer(IMediaService mediaService, IFileService fileService)
        {
            _mediaService = mediaService;
            _fileService = fileService;
        }

        public async Task Consume(ConsumeContext<UploadMediaMessage> context)
        {
            var message = context.Message;

            var byteData = Convert.FromBase64String(message.Base64);

            var fileUploadResult = await _fileService.UploadFileAsync(byteData, new MeArch.Module.File.Model.FileOptionsParameter
            {
                Directory = $"{CoreConfiguration.RootPath}/{Enum.GetName(typeof(MediaTypeEnum), message.MediaType)}",
                NameTemplate = message.FileName
            });

            if (!fileUploadResult.Success)
                throw new Exception("File Upload Exception");

            await _mediaService.CreateAsync(new Entities.Main.Media
            {
                MediaTypeId = (int)message.MediaType,
                MediaPath = message.FileName,
                EntityId = message.EntityId
            });
        }
    }
}
