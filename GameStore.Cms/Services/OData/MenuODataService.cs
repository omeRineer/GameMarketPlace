using GameStore.Cms.Services.Base;
using Core.Entities.Concrete.Menu;
using Entities.Main;
using Radzen;

namespace GameStore.Cms.Services.OData
{
    public class MenuODataService : BaseODataService<Menu>
    {
        public async Task<ODataServiceResult<Menu>> GetListAsync(ODataRequestParams requestParams)
            => await GetListAsync("menus", requestParams);

        public async Task<Menu> GetByIdAsync(Guid id)
            => await GetByIdAsync($"menus/{id}");
    }
}
