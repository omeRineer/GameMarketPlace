using Configuration;
using Hangfire;
using HangFire.Configuring;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSchedulerJobs(this IServiceCollection services)
        {
            services.AddScoped<IGeneralSchedulerService, GeneralSchedulerService>();

            services.AddHangfire(configuration =>
            {
                configuration.UseSqlServerStorage(CoreConfiguration.ConnectionString);
            });
            services.AddHangfireServer();
        }
    }
}
