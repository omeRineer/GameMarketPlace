using GameStore.Cms.Services.Base;
using Core.Entities.Concrete.Menu;
using Entities.Main;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class MenuService : BaseService<Menu>
    {
        public async Task<RestResponse<Menu>> GetByIdAsync(Guid id)
            => await GetByIdAsync($"/menus/getmenu/{id}");

        public async Task<RestResponse> AddAsync(Menu menu)
            => await AddAsync("/menus/add", menu);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync("/menus/delete", id);

        public async Task<RestResponse> UpdateAsync(Menu menu)
            => await UpdateAsync("/menus/update", menu);
    }
}
