using Configuration;
using Core.Utilities.RestHelper;
using RestSharp;

namespace CMS.Services.Base
{
    public class BaseService<TEntity>
    {
        protected async Task<RestResponse> AddAsync(string path, TEntity entity)
            => await RestHelper.PostAsync<TEntity, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}{path}"
            }, entity);

        protected async Task<RestResponse> DeleteAsync(string path, Guid id)
            => await RestHelper.PostAsync<Guid, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}{path}"
            }, id);

        protected async Task<RestResponse> UpdateAsync(string path, TEntity entity)
            => await RestHelper.PostAsync<TEntity, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}{path}"
            }, entity);

    }
}
