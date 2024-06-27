using CMS.Services.Base;
using Core.Entities.Concrete.Menu;
using Entities.Main;
using Radzen;

namespace CMS.Services.OData
{
    public class MenuODataService : BaseODataService<Menu>
    {
        public async Task<IEnumerable<Menu>> GetListAsync(ODataRequestParams requestParams)
            => await GetListAsync("menus", requestParams);

        public async Task<Menu> GetByIdAsync(Guid id)
            => await GetByIdAsync($"menus/{id}");
    }
}
