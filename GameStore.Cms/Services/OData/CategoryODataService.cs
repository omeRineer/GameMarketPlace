using GameStore.Cms.Services.Base;
using Entities.Main;
using Radzen;
using RestSharp;

namespace GameStore.Cms.Services.OData
{
    public class CategoryODataService : BaseODataService<Category>
    {
        public async Task<ODataServiceResult<Category>> GetListAsync(ODataRequestParams requestParams)
            => await GetListAsync("categories", requestParams);

        public async Task<Category> GetByIdAsync(Guid id)
            => await GetByIdAsync($"categories/{id}");
    }
}
