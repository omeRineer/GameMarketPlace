using GameStore.Cms.Services.Base;
using Core.Utilities.ResultTool;
using Entities.Main;
using RestSharp;
using Models.Category.Cms;

namespace GameStore.Cms.Services.Master
{
    public class CategoryService : BaseService
    {
        public CategoryService() : base("Categories") { }

        public async Task<RestResponse<SingleCategoryModel>> GetByIdAsync(Guid id)
            => await GetAsync<Guid, SingleCategoryModel>("getcategory", id);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync("delete", id);
    }
}
