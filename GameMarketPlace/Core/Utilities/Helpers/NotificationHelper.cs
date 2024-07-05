using Core.Entities.Concrete.ProcessGroups.Enums.Types;
using Core.Entities.DTO.Enterprise;
using Core.Utilities.ResultTool;
using Core.Utilities.ServiceTools;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public static class NotificationHelper
    {
        readonly static IBus Bus;

        static NotificationHelper()
        {
            Bus = StaticServiceProvider.GetService<IBus>();
        }

        public static async Task PublishAsync(string title, NotificationTypeEnum notificationType, object content)
        {
            await Bus.Publish(new CreateNotificationMessage
            {
                Type = notificationType,
                Title = title,
                Content = content
            });
        }
    }
}
