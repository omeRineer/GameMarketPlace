using Core.ServiceModules;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceModules
{
    public class BusinessServiceModule : IServiceModule
    {
        private readonly IConfiguration Configuration;

        public BusinessServiceModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Load(IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MeArchitecture;Trusted_Connection=True;");
            });

            services.AddMemoryCache();
        }
    }
}
