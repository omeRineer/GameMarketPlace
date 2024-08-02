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

        protected async Task<RestResponse<TModel>> GetAsync<TKey, TModel>(TKey id)
            => await RestHelper.GetAsync<TModel>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/{id}"
            });

        protected async Task<RestResponse> CreateAsync<TModel>(TModel entity)
            => await RestHelper.PostAsync<TModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/create"
            }, entity);

        protected async Task<RestResponse> DeleteAsync<TKey>(TKey id)
            => await RestHelper.PostAsync<TKey, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/delete"
            }, id);

        protected async Task<RestResponse> UpdateAsync<TModel>(TModel entity)
            => await RestHelper.PostAsync<TModel, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.WebApiUrl}/{Controller}/update"
            }, entity);

    }
}
