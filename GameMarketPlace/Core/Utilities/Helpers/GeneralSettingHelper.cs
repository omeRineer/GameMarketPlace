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


        public static async Task<TModel> GetFromCacheAsync<TModel>(string key, TModel defaultValue = default)
        {
            if (MemoryCache.TryGetValue(key, out TModel value))
                return value;

            var entitySetting = await GeneralSettings.SingleOrDefaultAsync(f => f.Key == key);


            return defaultValue;
        }
    }
}
