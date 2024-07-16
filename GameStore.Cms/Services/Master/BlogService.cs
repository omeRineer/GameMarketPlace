using GameStore.Cms.Model.Blog;
using GameStore.Cms.Model.SliderContent;
using GameStore.Cms.Services.Base;
using Configuration;
using Core.Utilities.RestHelper;
using Entities.Main;
using RestSharp;

namespace GameStore.Cms.Services.Master
{
    public class BlogService : BaseService<Blog>
    {
        public BlogService() : base("Blogs") { }

        public async Task<RestResponse> AddAsync(CreateBlogModel blogCreateModel)
            => await RestHelper.PostAsync<CreateBlogModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/create"
            }, blogCreateModel);

        public async Task<RestResponse> DeleteAsync(Guid id)
            => await DeleteAsync($"delete", id);
    }
}
