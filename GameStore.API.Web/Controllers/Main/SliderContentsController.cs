using Business.Services.Abstract;
using Entities.Main;
using Entities.Models.SliderContent.Rest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;
using Entities.Models.Game.Rest;

namespace GameStore.API.Web.Controllers.Main
{
    public class SliderContentsController : BaseController
    {
        readonly ISliderContentService _sliderContentService;

        public SliderContentsController(ISliderContentService sliderContentService)
        {
            _sliderContentService = sliderContentService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateSliderContentRequest request)
        {
            var result = await _sliderContentService.CreateAsync(request);

            return Result(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _sliderContentService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(UpdateSliderContentRequest request)
        {
            var result = await _sliderContentService.UpdateAsync(request);

            return Result(result);
        }
    }
}
