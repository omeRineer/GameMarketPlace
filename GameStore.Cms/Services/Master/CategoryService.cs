using GameStore.Cms.Services.Base;
using Core.Utilities.ResultTool;
using Entities.Main;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class CategoryService : BaseService<Category>
    {
        public CategoryService() : base("Categories") { }

        public async Task<RestResponse<Category>> GetByIdAsync(Guid id)
            => await GetByIdAsync("getcategory", id);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync("delete", id);
    }
}
