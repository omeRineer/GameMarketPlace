using Business.Services.Abstract;
using Entities.Dto.Media;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers.Main
{
    public class MediasController : BaseController
    {
        readonly IMediaService _mediaService;

        public MediasController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpPost("UploadMedia")]
        public async Task<IActionResult> UploadMedia([FromQuery] MediaUploadDto mediaUploadDto)
        {
            var result = await _mediaService.UploadMedia(mediaUploadDto);

            return Result(result);
        }
    }
}
