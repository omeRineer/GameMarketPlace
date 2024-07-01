﻿using Configuration;
using Core.ServiceModules;
using GameStore.Enterprise.Consumer.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Enterprise.Consumer.Modules
{
    public class RabbitMQServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<MediaUploadConsumer>();

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

                    cfg.ReceiveEndpoint("FileUploadQueue", rcfg =>
                    {
                        rcfg.ConfigureConsumer<MediaUploadConsumer>(context);
                        rcfg.UseMessageRetry(y =>
                        {
                            y.Interval(5, 10);
                        });
                    });
                });
            });

        }
    }

}
