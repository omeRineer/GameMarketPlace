using Configuration;
using Core.ServiceModules;
using MeArch.Module.Security.Helpers;
using MeArch.Module.Security.Extensions;
using MeArch.Module.Email.Extensions;
using MeArch.Module.File.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Business.ServiceModules
{
    public class MeArchitectureServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddDbContext<CoreContext>(options =>
            {
                options.UseSqlServer(CoreConfiguration.ConnectionString);
            });

            services.AddCors(options =>
                            options.AddDefaultPolicy(builder =>
                            builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

            services.AddMemoryCache();
            services.AddAutoMapper(typeof(BusinessServiceModule).Assembly);

            services
                  .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                  .AddCookie(opts =>
                  {
                      opts.Cookie.Name = $"GameStore.Token";   // todo : değiştirin.
                      opts.AccessDeniedPath = "/AccessDenied";
                      opts.LoginPath = "/Auth/Login";
                      opts.SlidingExpiration = true;
                  })
                  .AddJwtBearer(options =>
                  {
                      options.RequireHttpsMetadata = false;
                      options.SaveToken = true;
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                          ValidateIssuer = false,
                          ValidateAudience = false,
                          ValidateLifetime = true,
                          ValidateIssuerSigningKey = true,
                          IssuerSigningKey = SecurityKeyHelper.GetSecurityKey(CoreConfiguration.TokenOptions.SecurityKey)
                      };
                  });

            services.AddTokenService(options =>
            {
                options.Audience = CoreConfiguration.TokenOptions.Audience;
                options.Issuer = CoreConfiguration.TokenOptions.Issuer;
                options.ExpirationTime = CoreConfiguration.TokenOptions.ExpirationTime;
                options.SecurityKey = CoreConfiguration.TokenOptions.SecurityKey;
            });

            services.AddEmailService(options =>
            {
                options.Host = CoreConfiguration.EmailOptions.Host;
                options.Port = CoreConfiguration.EmailOptions.Port;
                options.UseSSL = CoreConfiguration.EmailOptions.UseSSL;
                options.UserName = CoreConfiguration.EmailOptions.UserName;
                options.Password = CoreConfiguration.EmailOptions.Password;
            });

            services.AddFileService(options =>
            {
                options.FilePath = CoreConfiguration.FileOptions.FilePath;
                options.Extensions = CoreConfiguration.FileOptions.Extensions;
            });

        }
    }
}
