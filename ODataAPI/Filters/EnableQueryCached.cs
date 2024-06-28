using Core.ServiceModules;
using Core.Utilities.ServiceTools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Caching.Memory;

namespace ODataAPI.Filters
{
    public class EnableQueryCached : EnableQueryAttribute
    {
        readonly IMemoryCache _memoryCache;
        string CacheKey = "OData.{0}";

        public EnableQueryCached()
        {
            _memoryCache = StaticServiceProvider.GetService<IMemoryCache>();
        }
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            CacheKey = string.Format(CacheKey, $"{actionExecutingContext.HttpContext.Request.Path}{actionExecutingContext.HttpContext.Request.QueryString}");

            if (_memoryCache.TryGetValue(CacheKey, out ObjectResult value))
            {
                actionExecutingContext.Result = value;
                return;
            }

            base.OnActionExecuting(actionExecutingContext);
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            _memoryCache.Set(CacheKey, actionExecutedContext.Result, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15)));
        }
    }
}
