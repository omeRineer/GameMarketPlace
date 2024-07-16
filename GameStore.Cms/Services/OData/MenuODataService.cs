using GameStore.Cms.Services.Base;
using Core.Entities.Concrete.Menu;
using Entities.Main;
using Radzen;

namespace GameStore.Cms.Services.OData
{
    public class MenuODataService : BaseODataService<Menu>
    {
        public MenuODataService() : base("Menus") { }
    }
}
