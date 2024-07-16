using GameStore.Cms.Services.Base;
using Entities.Main;
using Radzen;

namespace GameStore.Cms.Services.OData
{
    public class MediaODataService:BaseODataService<Media>
    {
        public MediaODataService() : base("Medias") { }
    }
}
