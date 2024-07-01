using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.DTO.Options
{
    public class MassTransitOptions
    {
        public RabbitMQOptions RabbitMQOptions { get; set; }
    }

    public class RabbitMQOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string VirtualHost { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
