using Configuration;
using Core.ServiceModules;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceModules
{
    public class MassTransitServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    var rabbitMqOptions = CoreConfiguration.MassTransitOptions.RabbitMQOptions;
                    cfg.Host(host: rabbitMqOptions.Host,
                             virtualHost: rabbitMqOptions.VirtualHost,
                             h =>
                             {
                                 h.Username(rabbitMqOptions.Username);
                                 h.Password(rabbitMqOptions.Password);
                             });
                });
            });
        }
    }
}
