using GameStore.Cms.Services.Base;
using Core.Entities.Concrete.Menu;
using Entities.Main;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class MenuService : BaseService
    {
        public MenuService() : base("Menus") { }

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync("delete", id);
    }
}
