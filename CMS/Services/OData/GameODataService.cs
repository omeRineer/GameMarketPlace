using CMS.Services.Base;
using Entities.Main;
using Radzen;

namespace CMS.Services.OData
{
    public class GameODataService : BaseODataService<Game>
    {
        public async Task<ODataServiceResult<Game>> GetListAsync(ODataRequestParams requestParams)
            => await GetListAsync("games", requestParams);
    }
}
