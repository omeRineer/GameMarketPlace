using Microsoft.Extensions.DependencyInjection;
using RazorLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Templates.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRazorLight(this IServiceCollection services, Action<RazorLightOptions> options)
        {
            services.AddRazorLight(options);

            return services;
        }
    }
}
