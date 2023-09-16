using Castle.Core.Internal;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.RestHelper
{
    public static class RestHelper
    {
        public static RestResponse<TResponse> Get<TResponse>(RestRequestParameter restRequestParameter,
                                                             Func<HttpRequestMessage, ValueTask> onBefore = null,
                                                             Func<HttpResponseMessage, ValueTask> onAfter = null)
        {
            var restClient = CreateClient();
            var request = CreateRestRequest(Method.Get, restRequestParameter);

            var response = restClient.Execute<TResponse>(request);

            return response;
        }
        public static async Task<RestResponse<TResponse>> GetAsync<TResponse>(RestRequestParameter restRequestParameter,
                                                                              Func<HttpRequestMessage, ValueTask> onBefore = null,
                                                                              Func<HttpResponseMessage, ValueTask> onAfter = null)
        {
            var restClient = CreateClient();
            var request = CreateRestRequest(Method.Get, restRequestParameter);

            var response = await restClient.ExecuteAsync<TResponse>(request);

            return response;
        }



        public static RestResponse<TResponse> Post<TRequest, TResponse>(RestRequestParameter restRequestParameter,
                                                                        TRequest body,
                                                                        Func<HttpRequestMessage, ValueTask> onBefore = null,
                                                                        Func<HttpResponseMessage, ValueTask> onAfter = null)
            where TRequest : class, new()
        {
            var restClient = CreateClient();
            var request = CreateRestRequest(Method.Post, restRequestParameter, body);

            var response = restClient.Execute<TResponse>(request);

            return response;
        }
        public static async Task<RestResponse<TResponse>> PostAsync<TRequest, TResponse>(RestRequestParameter restRequestParameter,
                                                                                         TRequest body,
                                                                                         Func<HttpRequestMessage, ValueTask> onBefore = null,
                                                                                         Func<HttpResponseMessage, ValueTask> onAfter = null)
        {
            var restClient = CreateClient();
            var request = CreateRestRequest(Method.Post, restRequestParameter, body);

            var response = await restClient.ExecuteAsync<TResponse>(request);

            return response;
        }



        private static RestClient CreateClient()
        {
            return new RestClient();
        }
        private static RestRequest CreateRestRequest(Method method,
                                                     RestRequestParameter restRequestParameter,
                                                     object? body = null,
                                                     Func<HttpRequestMessage, ValueTask> onBefore = null,
                                                     Func<HttpResponseMessage, ValueTask> onAfter = null)
        {

            var request = new RestRequest(restRequestParameter.BaseUrl, method);

            if (!string.IsNullOrEmpty(restRequestParameter.Authorization)) request.AddHeader("Authorization", restRequestParameter.Authorization);

            if (restRequestParameter.QueryParameters != null)
                foreach (var queryParam in restRequestParameter.QueryParameters)
                    request.AddQueryParameter(queryParam.Key, queryParam.Value.ToString());

            if (method == Method.Post && body != null) request.AddBody(body, restRequestParameter.ContentType ?? ContentType.Json);

            request.Timeout = restRequestParameter.TimeOut ?? 0;

            request.OnBeforeRequest = onBefore;
            request.OnAfterRequest = onAfter;

            return request;
        }
    }
}
