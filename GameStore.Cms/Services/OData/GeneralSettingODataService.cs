using Core.Entities.Concrete.GeneralSettings;
using Entities.Main;
using GameStore.Cms.Services.Base;
using Radzen;

namespace GameStore.Cms.Services.OData
{
    public class GeneralSettingODataService : BaseODataService<GeneralSetting>
    {
        public GeneralSettingODataService() : base("GeneralSettings") { }
    }
}
