using GameStore.Cms.Services.Base;
using Core.Entities.Concrete.ProcessGroups;
using Entities.Main;
using Radzen;

namespace GameStore.Cms.Services.OData
{
    public class TypeLookupODataService : BaseODataService<TypeLookup>
    {
        public TypeLookupODataService() : base("TypeLookups") { }
    }
}
