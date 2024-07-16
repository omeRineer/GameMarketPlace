using GameStore.Cms.Services.Base;
using Entities.Main;
using Radzen;

namespace GameStore.Cms.Services.OData
{
    public class SliderContentODataService : BaseODataService<SliderContent>
    {
        public SliderContentODataService() : base("SliderContents") { }
    }
}
