using Hangfire;
using HangFire.Configuring;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSchedulerJobs(this IApplicationBuilder app)
        {
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                AppPath = "/hangfire"
            });

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var service = serviceProvider.GetService<IGeneralSchedulerService>();

                service.Sync();
            }

            return app;
        }
    }
}
