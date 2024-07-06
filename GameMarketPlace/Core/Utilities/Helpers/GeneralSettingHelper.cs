using Core.Entities.Concrete.GeneralSettings;
using Core.Extensions;
using Core.Utilities.ServiceTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.GeneralSettingHelper
{
    public static class GeneralSettingHelper
    {
        private static DbContext Context;
        private static DbSet<GeneralSetting> GeneralSettings;
        private static IMemoryCache MemoryCache;
        static GeneralSettingHelper()
        {
            Context = StaticServiceProvider.GetService<DbContext>();
            GeneralSettings = Context.Set<GeneralSetting>();
            MemoryCache = StaticServiceProvider.GetService<IMemoryCache>();
        }

        public static async Task<TModel> GetOrSetAsync<TModel>(string key)
        {
            if (MemoryCache.TryGetValue(key, out TModel value))
                return value;

            var setting = await GeneralSettings.SingleOrDefaultAsync(f => f.Key == key);

            if (setting != null && setting.IsCached)
                MemoryCache.Set(key, setting, TimeSpan.FromMinutes(setting.CacheDuration ?? 30));

            return setting.Value.JsonDeserialize<TModel>();
        }

        public static async Task<GeneralSetting?> GetAsync(string key)
        {
            return await GeneralSettings.SingleOrDefaultAsync(f => f.Key == key);
        }

        public static async Task SetAsync(string key, object value, int cacheDuration = 30)
        {
            MemoryCache.Set(key, value, TimeSpan.FromMinutes(cacheDuration));
        }

        public static async Task RemoveAsync(string key)
        {
            MemoryCache.Remove(key);
        }
    }
}
