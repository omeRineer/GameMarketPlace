using Core.ServiceModules;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceModules
{
    public class CookieAuthenticationServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                  .AddCookie(opts =>
                  {
                      opts.Cookie.Name = $"GameStore.Token";
                      opts.AccessDeniedPath = "/AccessDenied";
                      opts.LoginPath = "/Auth/Login";
                      opts.SlidingExpiration = true;
                  });
        }
    }
}
