using GameStore.Cms.Services.Base;
using Configuration;
using Core.Utilities.RestHelper;
using Entities.Main;
using RestSharp;
using Models.Blog.Cms;
using Models.Category.Cms;

namespace GameStore.Cms.Services.Master
{
    public class BlogService : BaseService
    {
        public BlogService() : base("Blogs") { }

        public async Task<RestResponse<SingleBlogModel>> GetAsync(Guid id)
            => await GetAsync<Guid, SingleBlogModel>(id);

        public async Task<RestResponse> CreateAsync(CreateBlogModel model)
            => await CreateAsync(model);

        public async Task<RestResponse> UpdateAsync(UpdateBlogModel model)
            => await UpdateAsync(model);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync(id);
    }
}
