using GameStore.Cms.Services.Base;
using Configuration;
using Core.Utilities.RestHelper;
using Entities.Main;
using RestSharp;
using Models.SliderContent.Cms;

namespace GameStore.Cms.Services.Master
{
    public class SliderContentService : BaseService
    {
        public SliderContentService() : base("SliderContents") { }

        public async Task<RestResponse> CreateAsync(CreateSliderContentModel sliderContentCreateModel)
            => await RestHelper.PostAsync<CreateSliderContentModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/createslidercontent"
            }, sliderContentCreateModel);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync("delete", id);
    }
}
