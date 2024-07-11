using Core.Entities.Concrete.GeneralSettings;
using Entities.Main;
using GameStore.Cms.Services.Base;
using Radzen;

namespace GameStore.Cms.Services.OData
{
    public class GeneralSettingODataService : BaseODataService<GeneralSetting>
    {
        public async Task<ODataServiceResult<GeneralSetting>> GetListAsync(ODataRequestParams requestParams)
            => await GetListAsync("generalsettings", requestParams);

        public async Task<GeneralSetting> GetByIdAsync(Guid id)
            => await GetByIdAsync($"generalsettings/{id}");
    }
}
