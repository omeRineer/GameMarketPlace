using GameStore.Cms.Services.Base;
using Entities.Main;
using Radzen;

namespace GameStore.Cms.Services.OData
{
    public class MediaODataService:BaseODataService<Media>
    {
        public async Task<ODataServiceResult<Media>> GetListAsync(ODataRequestParams requestParams)
            => await GetListAsync("medias", requestParams);
    }
}
