using Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;
using Models.Media.WebService;

namespace GameStore.API.Web.Controllers.Main
{
    public class MediasController : BaseController
    {
        readonly IMediaService _mediaService;

        public MediasController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpPost("UploadMediaCollection")]
        public async Task<IActionResult> UploadMediaCollectionAsync(UploadMediaCollectionRequest request)
        {
            var result = await _mediaService.UploadMediaCollectionAsync(request);

            return Result(result);
        }

    }
}
