using Configuration;
using Core.Utilities.RestHelper;
using Core.Utilities.ResultTool;
using RestSharp;

namespace GameStore.Cms.Services.Base
{
    public class BaseService<TEntity>
    {
        protected readonly string Controller;
        public BaseService()
        {

        }
        public BaseService(string controller)
        {
            Controller = controller;
        }

        protected async Task<RestResponse<TEntity>> GetByIdAsync<TKey>(string actionName, TKey id)
            => await RestHelper.GetAsync<TEntity>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/{actionName}/{id}"
            });

        protected async Task<RestResponse> AddAsync(string path, TEntity entity)
            => await RestHelper.PostAsync<TEntity, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/{path}"
            }, entity);

        protected async Task<RestResponse> DeleteAsync<TKey>(string path, TKey id)
            => await RestHelper.PostAsync<TKey, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/{path}"
            }, id);

        protected async Task<RestResponse> UpdateAsync(string path, TEntity entity)
            => await RestHelper.PostAsync<TEntity, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/{path}"
            }, entity);

    }
}
