using CMS.Services.Base;
using Core.Entities.Concrete.ProcessGroups;
using Entities.Main;
using Radzen;

namespace CMS.Services.OData
{
    public class TypeLookupODataService : BaseODataService<TypeLookup>
    {
        public async Task<ODataServiceResult<TypeLookup>> GetListAsync(ODataRequestParams requestParams)
            => await GetListAsync("typelookups", requestParams);

        public async Task<TypeLookup> GetByIdAsync(Guid id)
            => await GetByIdAsync($"typelookups/{id}");
    }
}
