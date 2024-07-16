using GameStore.Cms.Services.Base;
using Entities.Main;
using Radzen;

namespace GameStore.Cms.Services.OData
{
    public class GameODataService : BaseODataService<Game>
    {
        public GameODataService() : base("Games") { }
    }
}
