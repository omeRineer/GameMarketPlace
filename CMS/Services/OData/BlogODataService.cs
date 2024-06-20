using CMS.Services.Base;
using Entities.Main;
using Radzen;

namespace CMS.Services.OData
{
    public class BlogODataService : BaseODataService<Blog>
    {
        public async Task<ODataServiceResult<Blog>> GetListAsync(ODataRequestParams requestParams)
            => await GetListAsync("blogs", requestParams);

        public async Task<Blog> GetByIdAsync(Guid id)
            => await GetByIdAsync($"blogs/{id}");
    }
}
