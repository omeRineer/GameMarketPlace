using DataAccess.Concrete.EntityFramework.General;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class ServiceExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ISystemRequirementRepository, SystemRequirementRepository>();
        }
    }
}
