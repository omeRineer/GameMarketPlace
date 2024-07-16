using Configuration;
using Core.Utilities.RestHelper;
using Core.Utilities.ResultTool.APIResult;
using Entities.Main;
using Newtonsoft.Json;
using Radzen;
using RestSharp;
using System.Net.Http.Json;

namespace GameStore.Cms.Services.Base
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
        protected readonly string Controller;

        public BaseODataService()
        {
            HttpClient = new HttpClient();
        }

        public BaseODataService(string controller) : this()
        {
            Controller = controller;
        }

        public async Task<ODataServiceResult<TEntity>> GetListAsync(ODataRequestParams requestParams)
        {
            var uri = new Uri($"{CoreConfiguration.ODataApiUrl}/{Controller}");
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

        public async Task<TEntity> GetByIdAsync(object id)
        {
            var uri = new Uri($"{CoreConfiguration.ODataApiUrl}/{Controller}/{id}");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await HttpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<TEntity>();

        }
    }
}
