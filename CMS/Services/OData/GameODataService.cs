using CMS.Services.Base;
using Entities.Main;
using Radzen;

namespace CMS.Services.OData
{
    public class GameODataService : BaseODataService<Game>
    {
        public async Task<IEnumerable<Game>> GetListAsync(ODataRequestParams requestParams)
            => await GetListAsync("games", requestParams);

        public async Task<Game> GetByIdAsync(Guid id)
            => await GetByIdAsync($"games/{id}");
    }
}
