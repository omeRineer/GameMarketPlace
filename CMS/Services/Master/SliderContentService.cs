using CMS.Model.SliderContent;
using CMS.Services.Base;
using Configuration;
using Core.Utilities.RestHelper;
using Entities.Main;
using RestSharp;

namespace CMS.Services.Master
{
    public class SliderContentService : BaseService<SliderContent>
    {
        public async Task<RestResponse> CreateSliderContentAsync(SliderContentCreateModel sliderContentCreateModel)
            => await RestHelper.PostAsync<SliderContentCreateModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/slidercontents/createslidercontent"
            }, sliderContentCreateModel);

        public async Task<RestResponse> AddAsync(SliderContent sliderContent)
            => await AddAsync("/slidercontents/add", sliderContent);
        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync("/slidercontents/delete", id);
        public async Task<RestResponse> UpdateAsync(SliderContent sliderContent)
            => await UpdateAsync("/slidercontents/update", sliderContent);
    }
}
