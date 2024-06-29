using GameStore.Cms.Model.Blog;
using GameStore.Cms.Model.SliderContent;
using GameStore.Cms.Services.Base;
using Configuration;
using Core.Utilities.RestHelper;
using Entities.Main;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class BlogService: BaseService<Blog>
    {
        public async Task<RestResponse> AddAsync(BlogCreateModel blogCreateModel)
            => await RestHelper.PostAsync<BlogCreateModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/blogs/create"
            }, blogCreateModel);

        public async Task<RestResponse<Blog>> GetByIdAsync(Guid id)
            => await GetByIdAsync($"/blogs/getblog/{id}");

        public async Task<RestResponse> AddAsync(Blog blog)
            => await AddAsync("/blogs/add", blog);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync("/blogs/delete", id);

        public async Task<RestResponse> UpdateAsync(Blog blog)
            => await UpdateAsync("/blogs/update", blog);
    }
}
