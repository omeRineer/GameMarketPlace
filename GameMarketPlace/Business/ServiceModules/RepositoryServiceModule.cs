using Core.ServiceModules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Business.ServiceModules
{
    public class RepositoryServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddRepositories();
        }
    }
}
