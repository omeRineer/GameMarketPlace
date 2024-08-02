using GameStore.Cms.Services.Master;
using GameStore.Cms.Services.OData;

namespace GameStore.Cms.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<CategoryService>();
            services.AddSingleton<GameService>();
            services.AddSingleton<MediaService>();
            services.AddSingleton<SliderContentService>();
            services.AddSingleton<MenuService>();
            services.AddSingleton<BlogService>();
        }

        public static void AddODataServices(this IServiceCollection services)
        {
            services.AddSingleton<CategoryODataService>();
            services.AddSingleton<GameODataService>();
            services.AddSingleton<MediaODataService>();
            services.AddSingleton<SliderContentODataService>();
            services.AddSingleton<TypeLookupODataService>();
            services.AddSingleton<MenuODataService>();
            services.AddSingleton<BlogODataService>();
            services.AddSingleton<GeneralSettingODataService>();
        }
    }
}
