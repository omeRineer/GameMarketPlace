using Business.Services.Abstract;
using Entities.Main;
using Entities.Models.SliderContent.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;

namespace GameStore.API.Web.Controllers.Main
{
    public class SliderContentsController : BaseController
    {
        readonly ISliderContentService _sliderContentService;

        public SliderContentsController(ISliderContentService sliderContentService)
        {
            _sliderContentService = sliderContentService;
        }
    }
}
