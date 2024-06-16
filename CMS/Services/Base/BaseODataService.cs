using Configuration;
using Core.Utilities.RestHelper;
using Entities.Main;
using Newtonsoft.Json;
using Radzen;
using RestSharp;
using System.Net.Http.Json;

namespace CMS.Services.Base
{
    public struct ODataRequestParams
    {
        public string? Filter { get; set; }
        public string? Select { get; set; }
        public int? Top { get; set; }
        public int? Skip { get; set; }
        public string? OrderBy { get; set; }
        public string? Expand { get; set; }
        public bool? Count { get; set; }
    }

    public class BaseODataService<TEntity>
        where TEntity : class, new()
    {
        readonly HttpClient HttpClient;

        public BaseODataService()
        {
            HttpClient = new HttpClient();
        }

        protected async Task<ODataServiceResult<TEntity>> GetListAsync(string path, ODataRequestParams requestParams)
        {
            var uri = new Uri($"{CoreConfiguration.ODataApiUrl}/{path}");
            var oDataUri = uri.GetODataUri(requestParams.Filter,
                                    requestParams.Top,
                                    requestParams.Skip,
                                    requestParams.OrderBy,
                                    requestParams.Expand,
                                    requestParams.Select,
                                    requestParams.Count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, oDataUri);

            var response = await HttpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<TEntity>>();

        }

        protected async Task<TEntity> GetByIdAsync(string path)
        {
            var uri = new Uri($"{CoreConfiguration.ODataApiUrl}/{path}");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await HttpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<TEntity>();

        }

        protected async Task<RestResponse> AddAsync(Category category)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(category));


            var response = await RestHelper.PostAsync<Category, object>(new RestRequestParameter
            {
                BaseUrl = $"{CoreConfiguration.ODataApiUrl}/odata/categories/add"
            }, category);

            return response;

        }
    }
}
