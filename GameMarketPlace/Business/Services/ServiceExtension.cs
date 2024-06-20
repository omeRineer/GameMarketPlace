using Business.Services.Abstract;
using Business.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<ISystemRequirementService, SystemRequirementService>();
            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<ISliderContentService, SliderContentService>();
            services.AddScoped<IMenuService, MenuService>();

            services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IPermissionSe, GameService>();
            //services.AddScoped<ISystemRequirementService, SystemRequirementService>();
            //services.AddScoped<ISystemRequirementService, SystemRequirementService>();
            //services.AddScoped<ISystemRequirementService, SystemRequirementService>();
        }
    }
}
