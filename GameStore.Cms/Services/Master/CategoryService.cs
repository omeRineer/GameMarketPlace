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

        public async Task<RestResponse> CreateAsync(CreateCategoryModel model)
            => await CreateAsync(model);

        public async Task<RestResponse> UpdateAsync(UpdateCategoryModel model)
            => await UpdateAsync(model);

        public async Task<RestResponse<SingleCategoryModel>> GetAsync(Guid id)
            => await GetAsync<Guid, SingleCategoryModel>(id);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync(id);
    }
}
