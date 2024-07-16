using GameStore.Cms.Services.Base;
using Entities.Main;
using Radzen;
using RestSharp;

namespace GameStore.Cms.Services.OData
{
    public class CategoryODataService : BaseODataService<Category>
    {
        public CategoryODataService() : base("Categories") { }
    }
}
