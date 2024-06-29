using GameStore.Cms.Services.Base;
using Entities.Main;
using Radzen;

namespace GameStore.Cms.Services.OData
{
    public class GameODataService : BaseODataService<Game>
    {
        public async Task<ODataServiceResult<Game>> GetListAsync(ODataRequestParams requestParams)
            => await GetListAsync("games", requestParams);

        public async Task<Game> GetByIdAsync(Guid id)
            => await GetByIdAsync($"games/{id}");
    }
}
