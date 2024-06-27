using Business.Services.Abstract;
using Entities.Main;
using Entities.Models.SliderContent.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers.Main
{
    public class SliderContentsController : BaseController
    {
        readonly ISliderContentService _sliderContentService;

        public SliderContentsController(ISliderContentService sliderContentService)
        {
            _sliderContentService = sliderContentService;
        }

        [HttpPost("CreateSliderContent")]
        public async Task<IActionResult> CreateSliderContent(SliderContentCreateDto sliderContentCreateDto)
        {
            var result = await _sliderContentService.CreateSliderContentAsync(sliderContentCreateDto);

            return Result(result);
        }
    }
}
