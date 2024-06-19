using CMS.Services.Base;
using Entities.Main;
using Radzen;

namespace CMS.Services.OData
{
    public class SliderContentODataService : BaseODataService<SliderContent>
    {
        public async Task<ODataServiceResult<SliderContent>> GetListAsync(ODataRequestParams requestParams)
            => await GetListAsync("slidercontents", requestParams);

        public async Task<SliderContent> GetByIdAsync(Guid id)
            => await GetByIdAsync($"slidercontents/{id}");
    }
}
