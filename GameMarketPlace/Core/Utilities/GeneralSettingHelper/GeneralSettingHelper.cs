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
    public static class GeneralSettingHelper<TContext>
        where TContext : DbContext
    {
        private static TContext Context;
        private static DbSet<GeneralSetting> GeneralSettings;
        private static IMemoryCache MemoryCache;
        static GeneralSettingHelper()
        {
            Context = StaticServiceProvider.GetService<TContext>();
            GeneralSettings = Context.Set<GeneralSetting>();
            MemoryCache = StaticServiceProvider.GetService<IMemoryCache>();
        }

        public static TModel AddOrUpdate<TModel>(string key, TModel value, bool isCached = true, int cacheDuration = 3)
        {
            var generalSetting = new GeneralSetting
            {
                Key = key,
                Value = value.JsonSerialize(),
                IsCached = isCached,
                CacheDuration = cacheDuration
            };

            var setting = GeneralSettings.FirstOrDefault(setting => setting.Key == key);
            if (setting != null)
            {
                setting.Key = generalSetting.Key;
                setting.Value = generalSetting.Value;
                setting.IsCached = generalSetting.IsCached;
                setting.CacheDuration = generalSetting.CacheDuration;

                GeneralSettings.Update(setting);
            }
            else
                GeneralSettings.Add(generalSetting);

            Context.SaveChanges();

            if (isCached && !MemoryCache.TryGetValue(key, out TModel model))
                return MemoryCache.Set(key, model, new MemoryCacheEntryOptions
                {
                    Priority = CacheItemPriority.Normal,
                    AbsoluteExpiration = DateTime.Now.AddMinutes(cacheDuration)
                });

            return value;
        }
        public static TModel GetOrSet<TModel>(string key)
        {
            if (MemoryCache.TryGetValue(key, out TModel model))
                return model;

            var data = GeneralSettings.Single(x => x.Key == key);
            var value = data.Value.JsonDeserialize<TModel>();

            if (data.IsCached)
                return MemoryCache.Set(key, value, new MemoryCacheEntryOptions
                {
                    Priority = CacheItemPriority.Normal,
                    AbsoluteExpiration = DateTime.Now.AddMinutes(data.CacheDuration ?? 3)
                });

            return value;
        }
        public static bool RemoveCache(string key)
        {
            if (!MemoryCache.TryGetValue(key, out object value))
                return false;

            MemoryCache.Remove(key);

            return true;
        }
        public static bool Remove(string key)
        {
            var data = GeneralSettings.FirstOrDefault(x => x.Key == key);
            if (data != null)
            {
                Context.Set<GeneralSetting>().Remove(data);
                Context.SaveChanges();
                RemoveCache(key);

                return true;
            }

            return false;
        }
    }
}
