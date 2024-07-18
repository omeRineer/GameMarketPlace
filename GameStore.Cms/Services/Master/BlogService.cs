using GameStore.Cms.Services.Base;
using Configuration;
using Core.Utilities.RestHelper;
using Entities.Main;
using RestSharp;
using Models.Blog.Cms;

namespace GameStore.Cms.Services.Master
{
    public class BlogService : BaseService
    {
        public BlogService() : base("Blogs") { }

        public async Task<RestResponse> CreateAsync(CreateBlogModel createBlogModel)
            => await CreateAsync("create", createBlogModel);

        public async Task<RestResponse> UpdateAsync(CreateBlogModel createBlogModel)
            => await CreateAsync("create", createBlogModel);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync($"delete", id);
    }
}
