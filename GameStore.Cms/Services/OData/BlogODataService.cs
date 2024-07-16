using GameStore.Cms.Services.Base;
using Entities.Main;
using Radzen;

namespace GameStore.Cms.Services.OData
{
    public class BlogODataService : BaseODataService<Blog>
    {
        public BlogODataService() : base("Blogs") { }
    }
}
