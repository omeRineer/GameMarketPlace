﻿using Configuration;
using Radzen;

namespace CMS.Services.OData
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
            var deg = CoreConfiguration.ODataApiUrl;
            var uri = (new Uri($"{CoreConfiguration.ODataApiUrl}/{path}"))
                       .GetODataUri(requestParams.Filter,
                                    requestParams.Top,
                                    requestParams.Skip,
                                    requestParams.OrderBy,
                                    requestParams.Expand,
                                    requestParams.Select,
                                    requestParams.Count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await HttpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<TEntity>>();

        }
    }
}
