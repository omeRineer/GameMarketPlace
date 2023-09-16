using MeArch.Module.Security.Model.Options;
using MeArch.Module.Security.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddTokenService(this IServiceCollection services, Action<TokenOptions> options)
        {
            services.Configure(options);
            services.AddSingleton<ITokenService, JwtService>();
        }
    }
}
