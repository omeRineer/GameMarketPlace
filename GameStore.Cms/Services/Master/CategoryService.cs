using GameStore.Cms.Services.Base;
using Core.Utilities.ResultTool;
using Entities.Main;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class CategoryService : BaseService<Category>
    {
        public async Task<RestResponse<Category>> GetByIdAsync(Guid id)
            => await GetByIdAsync($"/categories/getcategory/{id}");

        public async Task<RestResponse> AddAsync(Category category)
            => await AddAsync("/categories/add", category);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync("/categories/delete", id);

        public async Task<RestResponse> UpdateAsync(Category category)
            => await UpdateAsync("/categories/update", category);
    }
}
