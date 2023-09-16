using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.ServiceTools
{
    public static class StaticServiceProvider
    {
        private static IServiceProvider ServiceProvider { get; set; }
        public static IServiceProvider CreateInstance(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return ServiceProvider;
        }

        public static TService GetService<TService>()
        {
            return ServiceProvider.GetService<TService>();
        }
    }
}
