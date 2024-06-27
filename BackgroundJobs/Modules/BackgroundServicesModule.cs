using BackgroundJobs.Extensions;
using Core.ServiceModules;
using HangFire.Configuring;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration;

namespace BackgroundJobs.Modules
{
    public class BackgroundServicesModule : IServiceModule
    {
        public void Load(IServiceCollection services)
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
