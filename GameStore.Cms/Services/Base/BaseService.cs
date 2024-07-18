using Configuration;
using Core.Utilities.RestHelper;
using Core.Utilities.ResultTool;
using RestSharp;

namespace GameStore.Cms.Services.Base
{
    public class BaseService
    {
        protected readonly string Controller;
        public BaseService()
        {

        }
        public BaseService(string controller)
        {
            Controller = controller;
        }

        protected async Task<RestResponse<TModel>> GetAsync<TKey, TModel>(string actionName, TKey id)
            => await RestHelper.GetAsync<TModel>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/{actionName}/{id}"
            });

        protected async Task<RestResponse> CreateAsync<TModel>(string actionName, TModel entity)
            => await RestHelper.PostAsync<TModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/{actionName}"
            }, entity);

        protected async Task<RestResponse> DeleteAsync<TKey>(string actionName, TKey id)
            => await RestHelper.PostAsync<TKey, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/{actionName}"
            }, id);

        protected async Task<RestResponse> UpdateAsync<TModel>(string actionName, TModel entity)
            => await RestHelper.PostAsync<TModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/{actionName}"
            }, entity);

    }
}
