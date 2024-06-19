using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using Entities.Enum.Type;
using Entities.Main;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.ViewComponents
{
    public class CarouselViewComponent : ViewComponent
    {
        readonly ISliderContentService _sliderContentService;
        readonly IMediaService _mediaService;

        public CarouselViewComponent(ISliderContentService sliderContentService, IMediaService mediaService)
        {
            _sliderContentService = sliderContentService;
            _mediaService = mediaService;
        }

        public IViewComponentResult Invoke()
        {
            var sliderContents = Task.Run<IDataResult<List<SliderContent>>>(async () => await _sliderContentService.GetSliderContentByIsActive());
            var sliderMedias = Task.Run<IDataResult<List<Media>>>(async () => await _mediaService.GetMediaListByEntites(sliderContents.Result.Data.Select(s => s.Id).ToList()));

            ViewBag.SliderItems = sliderContents.Result.Data.Where(f => f.SliderTypeId == (int)SliderTypeEnum.SliderItem)
                                                     .OrderByDescending(o => o.EditDate)
                                                     .Select(s => new
                                                     {
                                                         Id = s.Id,
                                                         SliderType = s.SliderType,
                                                         Header = s.Header,
                                                         To = s.To,
                                                         IsActive = s.IsActive,
                                                         Image = sliderMedias.Result.Data.FirstOrDefault(f => f.EntityId == s.Id)
                                                     })
                                                     .ToList();

            ViewBag.SideSliderItems = sliderContents.Result.Data.Where(f => f.SliderTypeId == (int)SliderTypeEnum.SliderSideItem)
                                                         .OrderByDescending(o => o.EditDate)
                                                         .Take(5)
                                                         .Select(s => new
                                                         {
                                                             Id = s.Id,
                                                             SliderType = s.SliderType,
                                                             Header = s.Header,
                                                             To = s.To,
                                                             IsActive = s.IsActive,
                                                             Image = sliderMedias.Result.Data.FirstOrDefault(f => f.EntityId == s.Id)
                                                         })
                                                         .ToList();

            return View();
        }
    }
}
