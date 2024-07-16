using GameStore.Cms.Model.SliderContent;
using GameStore.Cms.Services.Base;
using Configuration;
using Core.Utilities.RestHelper;
using Entities.Main;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class SliderContentService : BaseService<SliderContent>
    {
        public SliderContentService() : base("SliderContents") { }

        public async Task<RestResponse> CreateAsync(SliderContentCreateModel sliderContentCreateModel)
            => await RestHelper.PostAsync<SliderContentCreateModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/createslidercontent"
            }, sliderContentCreateModel);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync("/slidercontents/delete", id);
    }
}
